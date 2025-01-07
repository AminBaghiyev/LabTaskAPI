using HospitalManagement.Core.Entities;
using HospitalManagement.DL.Contexts;
using HospitalManagement.DL.Repositories.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.DL.Repositories.Implementations;

public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
{
    public InsuranceRepository(AppDbContext context) : base(context) { }

    public override async Task<Insurance?> GetByIdAsync(int id) => await Table.Include(i => i.Patients).FirstOrDefaultAsync(i => i.Id == id);
}
