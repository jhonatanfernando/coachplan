using CoachPlan.Data.Context;
using CoachPlan.Domain.Entities;
using CoachPlan.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CoachPlan.Data.Repositories
{
    public class MuscleRepository : IMuscleRepository
    {
        private readonly CoachPlanContext _coachPlanContext;

        public MuscleRepository(CoachPlanContext coachPlanContext)
        {
            _coachPlanContext = coachPlanContext;
        }

        public async Task<int> Create(Muscle muscle)
        {
            _coachPlanContext.Muscles.Add(muscle);

            return await _coachPlanContext.SaveChangesAsync();
        }

        public async Task<int> Delete(Muscle muscle)
        {
            _coachPlanContext.Remove(muscle);

            return await _coachPlanContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Muscle>> GetAll()
        {
            return await _coachPlanContext.Muscles.ToListAsync();
        }

        public async Task<Muscle> GetById(int id)
        {
            return await _coachPlanContext.Muscles.Where(m => m.Id == id).SingleOrDefaultAsync();
        }

        public async Task<int> Update(Muscle muscle)
        {
            _coachPlanContext.Muscles.Update(muscle);
            
            return await _coachPlanContext.SaveChangesAsync();
        }
    }
}
