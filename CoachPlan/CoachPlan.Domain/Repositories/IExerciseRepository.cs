using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Repositories;

public interface IExerciseRepository
{
    Task<IEnumerable<Exercise>> GetAll();
    Task<Exercise> GetById(int id);
    Task<int> Create(Exercise exercise);
    Task<int> Update(Exercise exercise);
    Task<int> Delete(Exercise exercise);
}
