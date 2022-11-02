using System;
using System.Collections.Generic;

namespace SurveyModule.Models
{
    public partial class TblQuestionnaireOption
    {
        public int Id { get; set; }
        public int? TblQuestionnaireId { get; set; }
        public string? OptionDesc { get; set; }
        public int? OptionOrder { get; set; }
        public int? OptionScore { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }
        public sbyte? Isactive { get; set; }

        public virtual TblQuestionnaire? TblQuestionnaire { get; set; }
    }
}
