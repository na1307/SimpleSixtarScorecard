using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

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
        InitializeComponent();
    }
}
