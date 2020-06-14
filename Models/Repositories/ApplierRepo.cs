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
            return _context.Appliers
                .FirstOrDefault(applier => applier.Id == id);
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
                Position = applier.Phone,
                Phone = applier.Phone,
                ExpectedSalary = applier.ExpectedSalary,
            }).ToList();
        }

        public async Task<bool> AddApplier(Applier applier)
        {
            await _context.Appliers.AddAsync(applier);
            return await _context.SaveChangesAsync() > 0;
        }
    }
}