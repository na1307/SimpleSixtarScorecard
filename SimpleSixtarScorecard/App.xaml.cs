using CommunityToolkit.Mvvm.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System.IO;
using System.Text.Json;

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

        if (!File.Exists(Profile.ProfileFile)) {
            using FileStream fs = new(Profile.ProfileFile, FileMode.CreateNew, FileAccess.Write);
            using Utf8JsonWriter writer = new(fs);

            writer.WriteStartObject();
            writer.WriteString(Profile.UserNamePropertyName, string.Empty);
            writer.WriteStartArray(Profile.ResultsPropertyName);
            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
