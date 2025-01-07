using AutoMapper;
using HospitalManagement.BL.DTOs;
using HospitalManagement.BL.Exceptions.BaseExceptions;
using HospitalManagement.BL.Services.Abstractions;
using HospitalManagement.Core.Entities;
using HospitalManagement.DL.Repositories.Abstractions;

namespace HospitalManagement.BL.Services.Concretes;

public class PatientService : IPatientService
{
    readonly IRepository<Patient> _repository;
    readonly IInsuranceRepository _insuranceRepository;
    readonly IMapper _mapper;

    public PatientService(IRepository<Patient> repository, IInsuranceRepository insuranceRepository, IMapper mapper)
    {
        _repository = repository;
        _insuranceRepository = insuranceRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<PatientListItemDto>> GetAllAsync()
    {
        return _mapper.Map<ICollection<PatientListItemDto>>(await _repository.GetAllAsync());
    }

    public async Task<PatientDto> GetByIdAsync(int id)
    {
        Patient patient = await _repository.GetByIdAsync(id) ?? throw new EntityNotFoundException();
        PatientDto dto = _mapper.Map<PatientDto>(patient);
        dto.InsuranceName = (await _insuranceRepository.GetByIdAsNoTrackingAsync(patient.InsuranceId) ?? throw new EntityNotFoundException()).PersonInsurance;

        return dto;
    }

    public async Task<PatientDto> CreateAsync(PatientCreateDto dto)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsNoTrackingAsync(dto.InsuranceId) ?? throw new EntityNotFoundException();
        Patient patient = _mapper.Map<Patient>(dto);
        
        await _repository.CreateAsync(patient);

        PatientDto patientDto = _mapper.Map<PatientDto>(patient);
        patientDto.InsuranceName = insurance.PersonInsurance;

        return patientDto;
    }

    public async Task<PatientDto> UpdateAsync(PatientUpdateDto dto)
    {
        Insurance insurance = await _insuranceRepository.GetByIdAsNoTrackingAsync(dto.InsuranceId) ?? throw new EntityNotFoundException();
        Patient oldPatient = await _repository.GetByIdAsNoTrackingAsync(dto.Id) ?? throw new EntityNotFoundException();
        Patient newPatient = _mapper.Map<Patient>(dto);
        newPatient.CreatedAt = oldPatient.CreatedAt;
        newPatient.DeletedAt = oldPatient.DeletedAt;
        newPatient.IsDeleted = oldPatient.IsDeleted;

        _repository.Update(newPatient);

        PatientDto patientDto = _mapper.Map<PatientDto>(newPatient);
        patientDto.InsuranceName = insurance.PersonInsurance;

        return patientDto;
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
