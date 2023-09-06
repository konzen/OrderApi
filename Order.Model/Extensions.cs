using System.Globalization;

namespace Order.Model
{
    public static class Extensions
    {
        public static DateTime? ToDate(this string? value) =>
            DateTime.TryParseExact(value, "yyyy-MM-dd HH:mm:ss.FFF", CultureInfo.InvariantCulture, DateTimeStyles.AssumeLocal, out var date) ? date.ToLocalTime() : null;

        public static bool IsEmpty<T>(this T? obj) where T : class => obj != null && typeof(T).GetProperties().All(p => p.GetValue(obj) == null);
    }
}
