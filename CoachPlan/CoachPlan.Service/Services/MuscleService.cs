using CoachPlan.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CoachPlan.Service.Services;

public class MuscleService : IMuscleService
{
    private readonly IMuscleRepository _muscleRepository;

    public MuscleService(IMuscleRepository muscleRepository)
    {
        _muscleRepository = muscleRepository;
    }   

    public async Task<int> Create(MuscleDto muscleDto)
    {
        return await _muscleRepository.Create(muscleDto.ToModel());
    }

    public async Task<int> Delete(MuscleDto muscleDto)
    {
        return await _muscleRepository.Delete(muscleDto.ToModel());
    }

    public async Task<IEnumerable<GetMuscleDto>> GetAll()
    {
        var muscles = await _muscleRepository.GetAll();

        return muscles.ToGetDto();
    }

    public async Task<GetMuscleDto> GetById(int id)
    {
        var muscle = await _muscleRepository.GetById(id);

        return muscle.ToGetDto();
    }

    public async Task<int> Update(MuscleDto muscleDto)
    {
        return await _muscleRepository.Update(muscleDto.ToModel());
    }
}
