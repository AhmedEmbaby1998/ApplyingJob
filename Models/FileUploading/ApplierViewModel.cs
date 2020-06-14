using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Microsoft.AspNetCore.Http;

namespace JobApplying.Models.FileUploading
{
    public class ApplierViewModel
    {
        public string Name { set; get; }
        public DateTime BirthDate { set; get; }
        public string Email { set; get; }
        public string Phone { set; get; }
        public string City { set; get; }
        public string ZipCode { set; get; }
        public double ExpectedSalary { set; get; }
        public string MicrosoftOfficeGrade { set; get; }
        public double EnglishGrade { set; get; }
        public IFormFile Image { set; get; }
        public string Position { set; get; }
        public string GraduatingFaculty { set; get; }
        public int GraduatingYear { set; get; }
        public string GraduatingGrade { set; get; }
        public string Experiences { set; get; }
        public string PreviousPlaces { set; get; }

    }
}