using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using CoachPlan.Domain.Services;

namespace CoachPlan.Service.Services;

public class MuscleService : IMuscleService
{
    private readonly IMuscleRepository _muscleRepository;

    public MuscleService(IMuscleRepository muscleRepository)
    {
        _muscleRepository = muscleRepository;
    }   

    public async Task<int> Create(Muscle muscle)
    {
        return await _muscleRepository.Create(muscle);
    }

    public async Task<int> Delete(Muscle muscle)
    {
        return await _muscleRepository.Delete(muscle);
    }

    public async Task<IEnumerable<Muscle>> GetAll()
    {
        return await _muscleRepository.GetAll();
    }

    public async Task<Muscle> GetById(int id)
    {
        return await _muscleRepository.GetById(id);
    }

    public async Task<int> Update(Muscle muscle)
    {
        return await _muscleRepository.Update(muscle);
    }
}
