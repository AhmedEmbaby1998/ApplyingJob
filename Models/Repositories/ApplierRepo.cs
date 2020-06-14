using System;
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
            var app = _context.Appliers
                .FirstOrDefault(applier => applier.Id == id);
            if (app == null) return null;
            app.IsSeen = true;
            _context.SaveChanges();
            return app;

        }

        public List<PartialApplier> GetAllAppliers()
        {
            return _context.Appliers
                .AsEnumerable().Select(applier => new PartialApplier
                {
                    Name = applier.Name,
                    Id = applier.Id,
                    Age = DateTime.Now.Year - applier.BirthDate.Year,
                    IsSeen = applier.IsSeen,
                    Position = applier.Position,
                    Phone = applier.Phone,
                    ExpectedSalary = applier.ExpectedSalary,
                    ApplyingDateTime = applier.ApplyingDateTime
                }).OrderBy(applier => applier.IsSeen).ThenByDescending(applier => applier.ApplyingDateTime).ToList();
        }

        public async Task<bool> AddApplier(Applier applier)
        {
            await _context.Appliers.AddAsync(applier);
            return await _context.SaveChangesAsync() > 0;
        }

     
    }
}