using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleSixtarScorecard;

public sealed partial class App {
    public App() {
        ServiceCollection sc = new();

        sc.AddWpfBlazorWebView();
#if DEBUG
        sc.AddBlazorWebViewDeveloperTools();
#endif
        Ioc.Default.ConfigureServices(sc.BuildServiceProvider());
        InitializeComponent();
    }
}
