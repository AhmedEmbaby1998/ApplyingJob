using System.Collections.Generic;
using System.Threading.Tasks;
using JobApplying.Models;
using JobApplying.Models.Repositories;
using JobApplying.Models.Validators;
using Microsoft.AspNetCore.Mvc;

namespace JobApplying.Controllers
{
    public class ApplierController:Controller
    {
        private IApplierRepo<PartialApplier> _repo;

        public ApplierController(IApplierRepo<PartialApplier> repo)
        {
            _repo = repo;
        }
        [Route("Apply")]
        public IActionResult AddApplier()
        {
            return View();
        }
/**
        public Task<IActionResult> AddApplier(Applier applier)
        {
            var validation = new ValidateApplier(new List<IValidate<Applier>>()
            {
                new ValidateDates(),
                new ValidateEmail(),
                new ValidatePhone(),
                new ValidateName(),
            }, applier);
            
        }
        **/
        
    }
}