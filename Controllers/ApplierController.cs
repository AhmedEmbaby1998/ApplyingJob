﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using JobApplying.Models;
using JobApplying.Models.FileUploading;
using JobApplying.Models.Repositories;
using JobApplying.Models.Validators;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace JobApplying.Controllers
{
    public class ApplierController:Controller
    {
        private IApplierRepo<PartialApplier> _repo;
        private IWebHostEnvironment _environment;
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public ApplierController(IApplierRepo<PartialApplier> repo,SignInManager<IdentityUser> signInManager,UserManager<IdentityUser>userManager,IWebHostEnvironment environment)
        {
            _repo = repo;
            _environment = environment;
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [Microsoft.AspNetCore.Mvc.Route("Apply")]
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
                 PreviousPlaces = applier.PreviousPlaces,
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
       [Authorize]
        [Microsoft.AspNetCore.Mvc.Route("Appliers")]
        public IActionResult Appliers()
        {
            return View(_repo.GetAllAppliers());
        }
        [Authorize]
        public IActionResult Applier(int id)
        {
            return View(_repo.GetApplier(id));
        }

        [HttpGet]
        [Microsoft.AspNetCore.Mvc.Route("Login")]
        [Microsoft.AspNetCore.Mvc.Route("Admin")]

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                RedirectToAction("Appliers");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logins(LoginViewModel loginViewModel,string returnUrl)
        {
            
            var result =
                await _signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, true, false);
            if (result.Succeeded)
            {
                if (!String.IsNullOrEmpty(returnUrl)&&Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Appliers");
            }

            return RedirectToAction("Login");

        }
        /**
        [Microsoft.AspNetCore.Mvc.Route("signin")]
        public async Task<IActionResult> SignIn()
        {
            var user=new IdentityUser{UserName ="admin333" };
            var result = await _userManager.CreateAsync(user, "333");
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                RedirectToAction("Appliers");
            }

            var x = 3;
            return RedirectToAction("AddApplier");
        }

**/

    }
}