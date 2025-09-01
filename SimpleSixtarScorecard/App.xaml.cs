using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Windows;

namespace SimpleSixtarScorecard;

public sealed partial class App {
    public App() {
        ServiceCollection sc = new();

        sc.AddSqlite<SongContext>(null);
        sc.AddSqlite<ResultContext>(null);
        sc.AddWpfBlazorWebView();
#if DEBUG
        sc.AddBlazorWebViewDeveloperTools();
#endif
        sc.AddMudServices();
        Ioc.Default.ConfigureServices(sc.BuildServiceProvider());
        Ioc.Default.GetRequiredService<ResultContext>().Database.Migrate();

        if (File.Exists("profile.json")) {
            if (MessageBox.Show(
                    "이전 버전의 profile.json 파일이 있습니다. 이 파일을 새로운 저장 형식으로 업그레이드할까요? 업그레이드 후 프로그램을 다시 시작해야 합니다.\r\n\r\nprofile.json파일은 백업됩니다. 현재 저장 방식에 저장된 기록은 전부 삭제됩니다. 동의하지 않을 경우 프로그램을 사용할 수 없습니다.",
                    "알림", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes) {
                File.Delete("Result.db");

                var context = Ioc.Default.GetRequiredService<ResultContext>();

                context.Database.Migrate();

                var results = JsonNode.Parse(File.ReadAllBytes("profile.json"))!.AsObject()["results"].Deserialize<Result[]>(
                    new JsonSerializerOptions {
                        PropertyNameCaseInsensitive = true
                    })!;

                context.Results.AddRange(results);
                context.SaveChanges();
                File.Move("profile.json", "profile.bak.json");
            }

            Process.GetCurrentProcess().Kill();

            return;
        }

        InitializeComponent();
    }
}
