using CoachPlan.Domain.Dtos;

namespace CoachPlan.Domain.Services;

public interface IExerciseService
{
    Task<IEnumerable<ExerciseDto>> GetAll();
    Task<ExerciseDto> GetById(int id);
    Task<int> Create(ExerciseDto exerciseDto);
    Task<int> Update(ExerciseDto exerciseDto);
    Task<int> Delete(ExerciseDto exerciseDto);
}
