using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;

namespace SimpleSixtarScorecard;

public sealed partial class App {
    public App() {
        ServiceCollection sc = new();

        sc.AddWpfBlazorWebView();
#if DEBUG
        sc.AddBlazorWebViewDeveloperTools();
#endif
        sc.AddMudServices();
        Ioc.Default.ConfigureServices(sc.BuildServiceProvider());
        InitializeComponent();
    }
}
