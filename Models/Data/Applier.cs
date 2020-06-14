using System;
using System.Collections.Generic;

namespace JobApplying.Models
{
    public class Applier
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime BirthDate { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string City { set; get; }
        public string ZipCode { set; get; }
        public double ExpectedSalary { set; get; }
        public string MicrosoftOfficeGrade { set; get; }
        public double EnglishGrade { set; get; }
        public string Image { set; get; }
        public string GraduatingFaculty { set; get; }
        public string Experiences { set; get; }
        public string PreviousPlaces { set; get; }
        public int GraduatingYear { set; get; }
        public string GraduatingGrade { set; get; }
        public DateTime ApplyingDateTime { set; get; }
        public bool IsSeen { set; get; }
        public string Position { set; get; }
    }
}