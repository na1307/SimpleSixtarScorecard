namespace SimpleSixtarScorecard;

public static class DlcExtensions {
    public static string ToName(this Dlc dlc) {
        // Dlc 열거형의 DLC 이름을 반환함
        return dlc switch {
            Dlc.Base => "본편",
            Dlc.FlowerAndDestiny => "Flower & Destiny",
            Dlc.Touhou01 => "동방 프로젝트 팩 01",
            Dlc.LuminousAndDarkness => "Luminous & Darkness",
            Dlc.Pocotone => "포코톤",
            Dlc.YomohasPlanet => "Yomoha's Planet",
            Dlc.Wacca => "WACCA",
            Dlc.Oshiribeat => "오시리비트",
            Dlc.Dystopia => "디스토피아",
            _ => throw new NotImplementedException(),
        };
    }
}
