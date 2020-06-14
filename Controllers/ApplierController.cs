using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobApplying.Models;
using JobApplying.Models.FileUploading;
using JobApplying.Models.Repositories;
using JobApplying.Models.Validators;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace JobApplying.Controllers
{
    public class ApplierController:Controller
    {
        private IApplierRepo<PartialApplier> _repo;
        private IWebHostEnvironment _environment;
        private SignInManager<IdentityUser> _signInManager;

        public ApplierController(IApplierRepo<PartialApplier> repo,SignInManager<IdentityUser> signInManager,IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
            _signInManager = signInManager;
        }
        [Route("Apply")]
        [HttpGet]
        public IActionResult AddApplier()
        {
            return View();
        }

     

        [HttpPost]
        public async Task<IActionResult> AddAnApplier(ApplierViewModel applier)
        {
            var apply = new Applier
            {
                City = applier.City,
                Email = applier.Email,
                Experiences = applier.Experiences,
                Name = applier.Name,
                Phone = applier.Phone,
                Position = applier.Position,
                 BirthDate = applier.BirthDate,
                 EnglishGrade = applier.EnglishGrade,
                 ZipCode = applier.ZipCode,
                 ExpectedSalary = applier.ExpectedSalary,
                 PreviousPlaces = Request.Form["PreviousPlaces"],
                 GraduatingFaculty = applier.GraduatingFaculty,
                 ApplyingDateTime = DateTime.Now,
                 GraduatingGrade = applier.GraduatingGrade,
                  MicrosoftOfficeGrade = applier.MicrosoftOfficeGrade,
                  GraduatingYear = applier.GraduatingYear,
            };
            var validation = new ValidateApplier(new List<IValidate<Applier>>
            {
                new ValidateDates(),
                new ValidateEmail(),
                new ValidatePhone(),
                new ValidateName(),
            },apply);
            if (!validation.Validate())
            {
                Console.WriteLine("invalid validation ");
                return RedirectToAction("AddApplier");
            } 
            if (applier.Image!=null) 
            {
               var uploading =new UploadingFile(_environment,"images");
               await uploading.Upload(applier.Image);
               apply.Image = uploading.FileKey; 
            }

            if (await _repo.AddApplier(apply))
            {
                return RedirectToAction("SuccessActionResult");
            }

            return RedirectToAction("AddApplier");
        }

        public IActionResult SuccessActionResult()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Appliers()
        {
            return View(_repo.GetAllAppliers());
        }

        public IActionResult Applier(int id)
        {
            return View(_repo.GetApplier(id));
        }

        public IActionResult Login()
        {
            _signInManager.PasswordSignInAsync()
        }


     
    }
}