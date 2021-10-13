﻿using System.Threading;

namespace OTS.Ticketing.Win
{
    public static class LocalizationMessages
    {
        public static string GetMessage(string messageKey)
        {
            var culure = Thread.CurrentThread.CurrentCulture.ToString();
            if (culure.Contains("ar"))
                return messages_ar.ResourceManager.GetString(messageKey);
            else
                return messages_en.ResourceManager.GetString(messageKey);
        }
    }
}
