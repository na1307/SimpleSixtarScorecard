﻿using System.Text.Json.Serialization;

namespace SimpleSixtarScorecard;

[JsonConverter(typeof(JsonStringEnumConverter<Category>))]
public enum Category {
    Original = 1,
    Variety,
    Remix,
    Touhou,
    Collab
}
