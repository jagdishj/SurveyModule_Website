using System;
using System.Collections.Generic;

namespace SurveyModule.Models
{
    public partial class TblProject
    {
        public TblProject()
        {
            TblQuestionnaires = new HashSet<TblQuestionnaire>();
        }

        public int Id { get; set; }
        public string? ProjectName { get; set; }
        public string? ProjectDesc { get; set; }
        public sbyte? Scheduled { get; set; }
        public DateTime? ScheduledStartDatetime { get; set; }
        public DateTime? ScheduledEndDatetime { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }
        public sbyte? Isactive { get; set; }

        public virtual ICollection<TblQuestionnaire> TblQuestionnaires { get; set; }
    }
}
