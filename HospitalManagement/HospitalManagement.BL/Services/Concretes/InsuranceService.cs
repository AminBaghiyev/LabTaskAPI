using AutoMapper;
using HospitalManagement.BL.DTOs;
using HospitalManagement.BL.Exceptions.BaseExceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Concretes;

public class InsuranceService : IInsuranceService
{
    readonly IInsuranceRepository _repository;
    readonly IMapper _mapper;

    public InsuranceService(IInsuranceRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<ICollection<InsuranceListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<InsuranceListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<Insurance> GetByIdAsync(int id)
    {
        Insurance insurance = await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();

        return insurance;
    }

    public async Task<Insurance> CreateAsync(InsuranceCreateDto dto)
    {
        Insurance insurance = _mapper.Map<Insurance>(dto);

        await _repository.CreateAsync(insurance);
        return insurance;
    }

    public async Task<Insurance> UpdateAsync(InsuranceUpdateDto dto)
    {
        Insurance oldInsurance = await _repository.GetByIdAsNoTrackingAsync(dto.Id) ?? throw new EntityNotFoundException();
        Insurance newInsurance = _mapper.Map<Insurance>(dto);
        newInsurance.CreatedAt = oldInsurance.CreatedAt;
        newInsurance.DeletedAt = oldInsurance.DeletedAt;
        newInsurance.IsDeleted = oldInsurance.IsDeleted;

        _repository.Update(newInsurance);
        return newInsurance;
    }

    public async Task SoftDeleteAsync(int id)
    {
        _repository.SoftDelete(await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException());
    }

    public async Task HardDeleteAsync(int id)
    {
        _repository.HardDelete(await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException());
    }

    public async Task RecoverAsync(int id)
    {
        _repository.Recover(await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException());
    }

    public async Task<int> SaveChangesAsync() => await _repository.SaveChangesAsync();
}
