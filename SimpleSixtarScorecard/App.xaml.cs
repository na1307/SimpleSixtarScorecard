using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows;
using System.Windows.Threading;

namespace SimpleSixtarScorecard;

public sealed partial class App {
    private static readonly Mutex SingleInstanceMutex = new(true, "Global\\SimpleSixtarScorecard");

    public App() {
        if (!SingleInstanceMutex.WaitOne(TimeSpan.Zero, true)) {
            Process.GetCurrentProcess().Kill();

            return;
        }

        ServiceCollection sc = new();

        sc.AddDbContextFactory<SongContext>();
        sc.AddDbContextFactory<ResultContext>();
        sc.AddWpfBlazorWebView();
#if DEBUG
        sc.AddBlazorWebViewDeveloperTools();
#endif
        sc.AddMudServices();
        Ioc.Default.ConfigureServices(sc.BuildServiceProvider());

        using (var rc = Ioc.Default.GetRequiredService<IDbContextFactory<ResultContext>>().CreateDbContext()) {
            rc.Database.Migrate();
        }

        if (File.Exists("profile.json")) {
            if (MessageBox.Show(
                    "이전 버전의 profile.json 파일이 있습니다. 이 파일을 새로운 저장 형식으로 업그레이드할까요? 업그레이드 후 프로그램을 다시 시작해야 합니다.\r\n\r\nprofile.json파일은 백업됩니다. 현재 저장 방식에 저장된 기록은 전부 삭제됩니다. 동의하지 않을 경우 프로그램을 사용할 수 없습니다.",
                    "알림", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {
                File.Delete("Result.db");

                using var context = Ioc.Default.GetRequiredService<IDbContextFactory<ResultContext>>().CreateDbContext();

                context.Database.Migrate();

                var results = JsonNode.Parse(File.ReadAllBytes("profile.json"))!.AsObject()["results"].Deserialize<Result[]>()!;

                context.Results.AddRange(results);
                context.SaveChanges();
                File.Move("profile.json", "profile.backup.json");
            }

            Process.GetCurrentProcess().Kill();

            return;
        }

        GetSongDataUpdate().GetAwaiter().GetResult();
        InitializeComponent();
    }

    private static async Task GetSongDataUpdate() {
        string sdu;

        try {
            using HttpClient hc = new();
            using CancellationTokenSource cts = new(TimeSpan.FromSeconds(5));

            var uri
                = $"https://raw.githubusercontent.com/na1307/SimpleSixtarScorecard/refs/heads/main/songdataupdates/{AssemblyProperties.AssemblyInformationalVersion}.json";

            sdu = await hc.GetStringAsync(new Uri(uri), cts.Token);
        } catch (Exception e) when (e is TaskCanceledException or HttpRequestException) {
            // 무시
            return;
        }

        await using var context = await Ioc.Default.GetRequiredService<IDbContextFactory<SongContext>>().CreateDbContextAsync();
        var suo = JsonNode.Parse(sdu)!.AsObject();
        var newSongs = suo["new_songs"]?.AsArray().Deserialize<Song[]>();

        if (newSongs is not null && newSongs.Length != 0) {
            var zantetsuken = await context.Songs.FindAsync("zantetsuken") ?? throw new InvalidOperationException("Something went wrong");
            var targetOrder = zantetsuken.OrderNumber;

            await context.Songs.Where(s => s.OrderNumber >= targetOrder)
                .ExecuteUpdateAsync(s => s.SetProperty(b => b.OrderNumber, b => b.OrderNumber + newSongs.Length));

            foreach (var newSong in newSongs) {
                if (await context.Songs.AnyAsync(s => s.Id == newSong.Id)) {
                    continue;
                }

                await context.Songs.AddAsync(newSong with {
                    OrderNumber = targetOrder++
                });
            }

            await context.SaveChangesAsync();

            await context.Database.ExecuteSqlInterpolatedAsync($"""
                                                                CREATE TABLE OrderedSongs (
                                                                	"OrderNumber"	INTEGER NOT NULL UNIQUE,
                                                                	"Id"	TEXT NOT NULL UNIQUE,
                                                                	"Title"	TEXT NOT NULL,
                                                                	"Composer"	TEXT NOT NULL,
                                                                	"Dlc"	TEXT NOT NULL,
                                                                	"Category"	TEXT NOT NULL,
                                                                	"LunarComet"	INTEGER,
                                                                    "LunarNova"	INTEGER,
                                                                    "LunarSupernova"	INTEGER,
                                                                    "LunarQuasar"	INTEGER,
                                                                    "LunarStarlight"	INTEGER,
                                                                	"SolarComet"	INTEGER,
                                                                	"SolarNova"	INTEGER,
                                                                	"SolarSupernova"	INTEGER,
                                                                	"SolarQuasar"	INTEGER,
                                                                	"SolarStarlight"	INTEGER,
                                                                	PRIMARY KEY("Id")
                                                                );
                                                                """);

            await context.Database.ExecuteSqlInterpolatedAsync($"""
                                                                INSERT INTO OrderedSongs (
                                                                    OrderNumber,
                                                                    Id,
                                                                    Title,
                                                                    Composer,
                                                                    Dlc,
                                                                    Category,
                                                                    LunarComet,
                                                                    LunarNova,
                                                                    LunarSupernova,
                                                                    LunarQuasar,
                                                                    LunarStarlight,
                                                                    SolarComet,
                                                                    SolarNova,
                                                                    SolarSupernova,
                                                                    SolarQuasar,
                                                                    SolarStarlight
                                                                )
                                                                SELECT OrderNumber,
                                                                       Id,
                                                                       Title,
                                                                       Composer,
                                                                       Dlc,
                                                                       Category,
                                                                       LunarComet,
                                                                       LunarNova,
                                                                       LunarSupernova,
                                                                       LunarQuasar,
                                                                       LunarStarlight,
                                                                       SolarComet,
                                                                       SolarNova,
                                                                       SolarSupernova,
                                                                       SolarQuasar,
                                                                       SolarStarlight
                                                                FROM Songs
                                                                ORDER BY OrderNumber ASC;
                                                                """);

            await context.Database.ExecuteSqlInterpolatedAsync($"DROP TABLE Songs;");
            await context.Database.ExecuteSqlInterpolatedAsync($"ALTER TABLE OrderedSongs RENAME TO Songs;");
        }

        var updatedSongs = suo["updated_songs"]?.AsArray().Deserialize<Song[]>();

        if (updatedSongs is not null && updatedSongs.Length != 0) {
            foreach (var updated in updatedSongs) {
                var existing = await context.Songs.FindAsync(updated.Id);

                if (existing is null) {
                    continue;
                }

                context.Entry(existing).CurrentValues.SetValues(existing with {
                    Title = updated.Title ?? existing.Title,
                    Composer = updated.Composer ?? existing.Composer,
                    Dlc = updated.Dlc != Dlc.All ? updated.Dlc : existing.Dlc,
                    Category = updated.Category != Category.All ? updated.Category : existing.Category,
                    LunarComet = updated.LunarComet ?? existing.LunarComet,
                    LunarNova = updated.LunarNova ?? existing.LunarNova,
                    LunarSupernova = updated.LunarSupernova ?? existing.LunarSupernova,
                    LunarQuasar = updated.LunarQuasar ?? existing.LunarQuasar,
                    LunarStarlight = updated.LunarStarlight ?? existing.LunarStarlight,
                    SolarComet = updated.SolarComet ?? existing.SolarComet,
                    SolarNova = updated.SolarNova ?? existing.SolarNova,
                    SolarSupernova = updated.SolarSupernova ?? existing.SolarSupernova,
                    SolarQuasar = updated.SolarQuasar ?? existing.SolarQuasar,
                    SolarStarlight = updated.SolarStarlight ?? existing.SolarStarlight
                });
            }

            await context.SaveChangesAsync();
        }

        await context.Database.ExecuteSqlInterpolatedAsync($"VACUUM;");
    }

    private void App_OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e) {
#if !DEBUG
        e.Handled = true;
#endif

#pragma warning disable SA1113, SA1114, SA1115
        MessageBox.Show(e.Exception.
#if DEBUG
                ToString()
#else
                Message
#endif
            , null, MessageBoxButton.OK, MessageBoxImage.Error);
#pragma warning restore SA1114
    }
}
