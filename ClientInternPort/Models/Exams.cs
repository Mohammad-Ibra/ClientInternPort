using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInternPort.Models
{
    public partial class Exams
    {
        public int AssessmentId { get; set; }
        public string ExamUrl { get; set; }
        public int ProgramId { get; set; }
    }
}
