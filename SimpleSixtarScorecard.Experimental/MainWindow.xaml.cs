using CommunityToolkit.Mvvm.DependencyInjection;

namespace SimpleSixtarScorecard.Experimental;

public sealed partial class MainWindow {
    public MainWindow() {
        InitializeComponent();
        bw.Services = Ioc.Default;
    }
}
