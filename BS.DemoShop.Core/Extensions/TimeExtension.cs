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
            var timeZoneInfo = TZConvert.GetTimeZoneInfo("Asia/Taipei");
            var localTime = TimeZoneInfo.ConvertTime(utcDateTime, timeZoneInfo);
            return localTime;
        }
    }
}
