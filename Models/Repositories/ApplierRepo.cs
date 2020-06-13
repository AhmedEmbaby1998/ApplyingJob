﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace JobApplying.Models.Repositories
{
    
    public class ApplierRepo:IApplierRepo<PartialApplier>
    {
        private ApplicationContext _context;

        public ApplierRepo(ApplicationContext context)
        {
            _context = context;
        }
        public Applier GetApplier(int id)
        {
            return _context.Appliers.Where(applier => applier.Id == id)
                .Include(applier => applier.Position)
                .Include(applier => applier.Experiences)
                .Include(applier => applier.PreviousWorks)
                .FirstOrDefault();
        }

        public List<PartialApplier> GetAllAppliers()
        {
            return _context.Appliers
                .AsEnumerable().Select(applier => new PartialApplier
            {
                Name = applier.Name,
                Id = applier.Id,
                Age =DateTime.Now.Year-applier.BirthDate.Year,
                IsSeen = applier.IsSeen,
                ExpectedSalary = applier.ExpectedSalary
            }).ToList();
        }

        public async Task<bool> AddApplier(Applier applier)
        {
            await _context.Appliers.AddAsync(applier);
            return _context.SaveChanges() > 0;
        }
    }
}