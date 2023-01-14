using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Repositories;

public interface IMuscleRepository
{
    Task<IEnumerable<Muscle>> GetAll();
    Task<Muscle> GetById(int id);
    Task<int> Create(Muscle muscle);
    Task<int> Update(Muscle muscle);
    Task<int> Delete(Muscle muscle);
}
