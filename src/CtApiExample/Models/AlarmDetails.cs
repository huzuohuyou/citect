using SqlSugar;

namespace CtApiExample.Models
{
    [SugarTable("AlarmDetails")]
    public class AlarmDetails
    {
        

        public string CurrentDateTime { get; set; }// NbApiExampleController.CurrentDateTime;
        public string CurrentTs { get; set; } //= NbApiExampleController.CurrentTs;
        public int Count { get; set; } //= NbApiExampleController.Count;
        public string tag { get; set; }
        public string category { get; set; }
        public string equip { get; set; }
        public string msg { get; set; }
        public string desc { get; set; }
        public string state { get; set; }
        public string ts { get; set; }
        public string comment { get; set; }
        public string type { get; set; }
        public string alarmState { get; set; }
        public string cost { get; set; }

    }
}
