using System.Globalization;

namespace Employees.Core.Services;

public static class DateParser
{
    private static readonly string[] Formats =
    {
        "yyyy-MM-dd", "dd-MM-yyyy", "MM/dd/yyyy", "dd/MM/yyyy",
        "yyyy/MM/dd", "M/d/yyyy", "d.M.yyyy"
    };

    public static DateTime Parse(string value)
    {
        if (value.Trim().Equals("NULL", StringComparison.OrdinalIgnoreCase))
            return DateTime.Today;

        return DateTime.ParseExact(
            value.Trim(),
            Formats,
            CultureInfo.InvariantCulture,
            DateTimeStyles.None
        );
    }
}
