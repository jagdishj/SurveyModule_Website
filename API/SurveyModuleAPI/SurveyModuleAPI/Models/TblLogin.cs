using System;
using System.Collections.Generic;

namespace SurveyModule.Models
{
    public partial class TblLogin
    {
        public int Id { get; set; }
        public string? Loginid { get; set; }
        public string? Password { get; set; }
        public int? Createdby { get; set; }
        public DateTime? Createdat { get; set; }
        public int? Modifiedby { get; set; }
        public DateTime? Modifiedat { get; set; }
        public sbyte? Isactive { get; set; }
    }
}
