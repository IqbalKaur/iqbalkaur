namespace IksBlog.Web.Helpers;

public static class DateDisplayHelper
{
    public static string FormatUtcToEst(string createdAt)
    {
        if (string.IsNullOrWhiteSpace(createdAt))
        {
            return string.Empty;
        }

        var timeUtc = DateTime.Parse(createdAt, null, System.Globalization.DateTimeStyles.RoundtripKind);
        if (timeUtc.Kind == DateTimeKind.Unspecified)
        {
            timeUtc = DateTime.SpecifyKind(timeUtc, DateTimeKind.Utc);
        }
        else if (timeUtc.Kind == DateTimeKind.Local)
        {
            timeUtc = timeUtc.ToUniversalTime();
        }

        var estZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
        var estTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, estZone);
        return estTime.ToString("g");
    }
}
