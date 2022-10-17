using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace ClientInternPort.Models
{
    public partial class Instructors
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public bool InstructorEmployer { get; set; }
        public string Major { get; set; }
        public int ProgramId { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
