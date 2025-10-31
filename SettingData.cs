using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountInfoManager
{
    public class SettingData
    {
        public bool firstFlag { get; set; }
        public Setting settings { get; set; }
    }

    public class Setting
    {
        public bool DeletionNotificationFlag { get; set; }
        public bool SaveNotificationFlag { get; set; }
        public bool AutoSaveFlag { get; set; }
        public bool TimeOutFlag { get; set; }
        public int TimeOutMinutes { get; set; }
    }
}
