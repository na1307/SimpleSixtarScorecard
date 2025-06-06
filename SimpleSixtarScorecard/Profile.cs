﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

internal sealed class Profile {
    public const string ProfileFile = "profile.json";
    public const string UserNamePropertyName = "username";
    public const string ResultsPropertyName = "results";
    private static readonly ProfileConverter Converter = new(ProfileFile);
    private static readonly Lazy<Profile> InstanceField = new(Converter.Load);
    private static readonly JsonWriterOptions IndentedWriterOptions = new() { Indented = true };

    private Profile() { }

    public static Profile Instance => InstanceField.Value;

    [field: AllowNull]
    [field: MaybeNull]
    public string UserName {
        get;
        set {
            if (field != value) {
                var oldValue = field;
                field = value;

                if (oldValue != null) {
                    SaveProfile();
                }
            }
        }
    }

    public ObservableCollection<Result> Results {
        get;
        private init {
            field = value;
            value.ForEach(result => result.PropertyChanged += (_, _) => SaveProfile());

            field.CollectionChanged += (_, e) => {
                e.NewItems?.Cast<INotifyPropertyChanged>().ForEach(inpc => inpc.PropertyChanged += (_, _) => SaveProfile());
                SaveProfile();
            };
        }
    } = [];

    public override string ToString() {
        MemoryStream ms = new(10240);

        using (Utf8JsonWriter writer = new(ms, IndentedWriterOptions)) {
            Converter.Write(writer, this, new());
        }

        return Encoding.UTF8.GetString(ms.ToArray());
    }

    private void SaveProfile() => Converter.Save(this);

    private sealed class ProfileConverter(string fileName) : JsonConverter<Profile> {
        public Profile Load() {
            Utf8JsonReader reader = new(File.ReadAllBytes(fileName));

            return Read(ref reader, typeof(Profile), new());
        }

        public void Save(Profile settings) {
            using FileStream fs = new(fileName, FileMode.Truncate, FileAccess.Write, FileShare.None);
            using Utf8JsonWriter writer = new(fs, IndentedWriterOptions);

            Write(writer, settings, new());
        }

        public override Profile Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options) {
            var jo = JsonNode.Parse(ref reader)!.AsObject();

            return new() {
                UserName = jo[UserNamePropertyName]!.ToString(),
                Results = [.. jo[ResultsPropertyName]!.AsArray().Cast<JsonObject>().Select(obj => new Result {
                    SongId = obj[Result.SongIdPropertyName]!.ToString(),
                    Mode = parseEnum<Mode>(obj[Result.ModePropertyName]),
                    Difficulty = parseEnum<Difficulty>(obj[Result.DifficultyPropertyName]),
                    Score = int.Parse(obj[Result.ScorePropertyName]!.ToString()),
                    FullCombo = bool.Parse(obj[Result.FullComboPropertyName]!.ToString()),
                })],
            };

            static TEnum parseEnum<TEnum>(JsonNode? node) where TEnum : struct, Enum => Enum.TryParse<TEnum>(node?.ToString(), true, out var value) ? value : default;
        }

        public override void Write(Utf8JsonWriter writer, Profile value, JsonSerializerOptions options) {
            writer.WriteStartObject();
            writer.WriteString(UserNamePropertyName, value.UserName);
            writer.WriteStartArray(ResultsPropertyName);

            foreach (var result in value.Results) {
                writer.WriteStartObject();
                writer.WriteString(Result.SongIdPropertyName, result.SongId);
                writer.WriteString(Result.ModePropertyName, result.Mode.ToString().ToLower());
                writer.WriteString(Result.DifficultyPropertyName, result.Difficulty.ToString().ToLower());
                writer.WriteNumber(Result.ScorePropertyName, result.Score);
                writer.WriteBoolean(Result.FullComboPropertyName, result.FullCombo);
                writer.WriteEndObject();
            }

            writer.WriteEndArray();
            writer.WriteEndObject();
        }
    }
}
