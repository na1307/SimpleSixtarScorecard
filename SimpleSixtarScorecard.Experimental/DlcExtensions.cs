namespace SimpleSixtarScorecard;

internal static class DlcExtensions {
    public static string ToName(this Dlc dlc)
        => dlc switch {
            Dlc.All => "전체",
            Dlc.Base => "본편",
            Dlc.FlowerAndDestiny => "Flower & Destiny",
            Dlc.Touhou01 => "동방 프로젝트 팩 01",
            Dlc.LuminousAndDarkness => "Luminous & Darkness",
            Dlc.Pocotone => "포코톤",
            Dlc.YomohasPlanet => "yomoha's Planet",
            Dlc.Wacca => "WACCA 콜라보레이션",
            Dlc.Oshiribeat => "오시리비트",
            Dlc.Dystopia => "디스토피아",
            Dlc.UnitedNetwalk => "UNITED NETWALK",
            Dlc.Kalpa => "KALPA 콜라보레이션",
            _ => throw new NotImplementedException(),
        };
}
