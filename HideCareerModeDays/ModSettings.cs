using System;
using Newtonsoft.Json;

namespace HideCareerModeDays
{
    public class ModSettings
    {
        public bool HideAlways = false;

        public static ModSettings ReadSettings(string json)
        {
            try
            {
                return JsonConvert.DeserializeObject<ModSettings>(json);
            }
            catch (Exception)
            {
                return new ModSettings();
            }
        }
    }
}
