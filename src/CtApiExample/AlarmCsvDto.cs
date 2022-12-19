using SqlSugar;
using System;

namespace CtApiExample
{
    /// <summary>
    /// Class Alarm.
    /// </summary>
   
    public class AlarmCsvDto
    {
        /// <summary>
        /// Gets or sets the tag.
        /// </summary>
        /// <value>The tag.</value>
        public string Tag { get; set; }

        /// <summary>
        /// the timestamp of get alarm
        /// </summary>
        public DateTime TimestampCurrent { get; set; }

        /// <summary>
        /// Gets or sets the timestamp occurrence.
        /// This is the converted "TIMETICKS" property.
        /// </summary>
        /// <value>The timestamp occurrence.</value>
        public DateTime TimestampOccurrence { get; set; }

        public string Message { get; set; }

        /// <summary>
        /// the cost of get alarm
        /// </summary>
        public string Cost { get; set; }

        
    }
}
