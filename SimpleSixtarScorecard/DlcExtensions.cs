using static SimpleSixtarScorecard.Properties.Strings;

namespace SimpleSixtarScorecard;

internal static class DlcExtensions {
    public static string ToName(this Dlc dlc)
        // Returns the DLC name from the Dlc value.
        => dlc switch {
            Dlc.Base => DlcBase,
            Dlc.FlowerAndDestiny => DlcFlowerAndDestiny,
            Dlc.Touhou01 => DlcTouhou01,
            Dlc.LuminousAndDarkness => DlcLuminousAndDarkness,
            Dlc.Pocotone => DlcPocotone,
            Dlc.YomohasPlanet => DlcYomohasPlanet,
            Dlc.Wacca => DlcWacca,
            Dlc.Oshiribeat => DlcOshiribeat,
            Dlc.Dystopia => DlcDystopia,
            Dlc.UnitedNetwalk => DlcUnitedNetwalk,
            Dlc.Kalpa => DlcKalpa,
            _ => throw new NotImplementedException(),
        };
}
