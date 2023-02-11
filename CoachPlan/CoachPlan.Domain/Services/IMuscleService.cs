using CoachPlan.Domain.Dtos;

namespace CoachPlan.Domain.Services;

public interface IMuscleService
{
    Task<IEnumerable<GetMuscleDto>> GetAll();
    Task<GetMuscleDto> GetById(int id);
    Task<int> Create(MuscleDto muscleDto);
    Task<int> Update(MuscleDto muscleDto);
    Task<int> Delete(MuscleDto muscleDto);
}
