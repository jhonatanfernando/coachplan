namespace CoachPlan.Data.Repositories;

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

        await _coachPlanContext.SaveChangesAsync();

        return muscle.Id;
    }

    public async Task<int> Delete(Muscle muscle)
    {
        _coachPlanContext.Remove(muscle);

        return await _coachPlanContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Muscle>> GetAll()
    {
        return await _coachPlanContext.Muscles.Include(d=> d.Exercises).ToListAsync();
    }

    public async Task<Muscle> GetById(int id)
    {
        return await _coachPlanContext.Muscles.AsNoTracking().Include(d => d.Exercises).Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task<int> Update(Muscle muscle)
    {
        _coachPlanContext.Muscles.Update(muscle);
        
        return await _coachPlanContext.SaveChangesAsync();
    }
}
