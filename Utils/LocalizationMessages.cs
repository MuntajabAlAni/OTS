using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OTS.Ticketing.Win
{
    public static class LocalizationMessages
    {
        public static string GetMessage(string messageKey) {
            var culure = Thread.CurrentThread.CurrentCulture.ToString();
            if (culure.Contains("ar"))
                return messages_ar.ResourceManager.GetString(messageKey);
            else
                return messages_en.ResourceManager.GetString(messageKey);
        }
    }
}
