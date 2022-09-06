using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace BS.DemoShop.Core.Extensions
{
    public static class TimeExtension
    {
        /// <summary>
        /// UTC 時間轉為台灣時區擴充方法
        /// </summary>
        /// <param name="utcDateTime">UTC +0 DateTime</param>
        /// <returns></returns>
        public static DateTime ToTaiwaneseTime(this DateTime utcDateTime)
        {
            string displayName = "(GMT+08:00) Taiwan/Taipei Time";
            string standardName = "Taipei Time";
            TimeSpan offset = new TimeSpan(08, 00, 00);
            TimeZoneInfo taipeiTimeZone = TimeZoneInfo.CreateCustomTimeZone(standardName, offset, displayName, standardName);
           
            var localTime = TimeZoneInfo.ConvertTime(utcDateTime, TimeZoneInfo.Utc, taipeiTimeZone);
            return localTime;
        }
    }
}
