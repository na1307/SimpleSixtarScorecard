using System.Globalization;
using System.Text;

namespace SimpleSixtarScorecard;

internal static class StringExtensions {
#if !NETCOREAPP2_1_OR_GREATER && !NETCOREAPP3_0_OR_GREATER && !NETSTANDARD2_1_OR_GREATER
    public static bool Contains(this string source, string toCheck, StringComparison comp) => source?.IndexOf(toCheck, comp) >= 0;

#endif
    public static string RemoveDiacritics(this string text) {
        var normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new(capacity: normalizedString.Length);

        for (var i = 0; i < normalizedString.Length; i++) {
            var c = normalizedString[i];
            var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);

            if (unicodeCategory != UnicodeCategory.NonSpacingMark) {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
    }
}
