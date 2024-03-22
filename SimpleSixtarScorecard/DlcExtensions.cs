namespace SimpleSixtarScorecard;

public static class DlcExtensions {
    public static string ToName(this Dlc dlc) {
        // Returns the DLC name from the Dlc value.
        return dlc switch {
            Dlc.Base => "Base game",
            Dlc.FlowerAndDestiny => "Flower & Destiny",
            Dlc.Touhou01 => "Touhou Project Pack 01",
            Dlc.LuminousAndDarkness => "Luminous & Darkness",
            Dlc.Pocotone => "POCOTONE",
            Dlc.YomohasPlanet => "Yomoha's Planet",
            Dlc.Wacca => "WACCA",
            Dlc.Oshiribeat => "Oshiribeat",
            Dlc.Dystopia => "Dystopia",
            _ => throw new NotImplementedException(),
        };
    }
}
