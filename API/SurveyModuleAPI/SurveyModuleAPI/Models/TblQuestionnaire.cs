using System;
using System.Collections.Generic;

namespace SurveyModule.Models
{
    public partial class TblQuestionnaire
    {
        public TblQuestionnaire()
        {
            TblQuestionnaireOptions = new HashSet<TblQuestionnaireOption>();
        }

        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string? Question { get; set; }
        public string? QuestionDesc { get; set; }
        public int? QuestionOrder { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }
        public sbyte? Isactive { get; set; }

        public virtual TblProject? Project { get; set; }
        public virtual ICollection<TblQuestionnaireOption> TblQuestionnaireOptions { get; set; }
    }
}
