using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace JobApplying.Models.FileUploading
{
    public class ApplierViewModel
    {
        public ApplierViewModel()
        {
            Experiences=new List<Experience>();
            PreviousWorks=new List<PreviousWork>();
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public DateTime BirthDate { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string Government { set; get; }
        public string City { set; get; }
        public string ZipCode { set; get; }
        public double ExpectedSalary { set; get; }
        public double MicrosoftOfficeGrade { set; get; }
        public double EnglishGrade { set; get; }
        public IFormFile Image { set; get; }
        public string GraduatingFaculty { set; get; }
        public int GraduatingYear { set; get; }
        public int GraduatingGrade { set; get; }
        public DateTime ApplyingDateTime { set; get; }
        public bool IsSeen { set; get; }
        public IList<Experience> Experiences { set; get; }
        public IList<PreviousWork>PreviousWorks { set; get; }
    }
}