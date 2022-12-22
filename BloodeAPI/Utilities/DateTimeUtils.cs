using System;
namespace BloodeAPI.Utilities
{
	public static class DateTimeUtils
	{
        public static DateTime ToUTC(this DateTime date)
        {
            return date.ToUniversalTime();
        }

        public static DateTime ToIST(this DateTime date)
        {
            DateTime temp = new DateTime(date.Ticks, DateTimeKind.Utc);
            return TimeZoneInfo.ConvertTimeFromUtc(temp, TimeZoneInfo.FindSystemTimeZoneById("India Standard Time"));
        }

        public static bool IsUTC(this DateTime date)
        {
            return date.Kind == DateTimeKind.Utc;
        }
    }
}

