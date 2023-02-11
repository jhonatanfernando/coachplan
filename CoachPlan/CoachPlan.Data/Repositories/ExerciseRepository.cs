namespace CoachPlan.Data.Repositories;

public class ExerciseRepository : IExerciseRepository
{
    private readonly CoachPlanContext _coachPlanContext;

    public ExerciseRepository(CoachPlanContext coachPlanContext)
    {
        _coachPlanContext = coachPlanContext;
    }

    public async Task<int> Create(Exercise exercise)
    {
        _coachPlanContext.Exercises.Add(exercise);

        return await _coachPlanContext.SaveChangesAsync();
    }

    public async Task<int> Delete(Exercise exercise)
    {
        _coachPlanContext.Remove(exercise);

        return await _coachPlanContext.SaveChangesAsync();
    }

    public async Task<IEnumerable<Exercise>> GetAll()
    {
        return await _coachPlanContext.Exercises.ToListAsync();
    }

    public async Task<Exercise> GetById(int id)
    {
        return await _coachPlanContext.Exercises.Where(m => m.Id == id).SingleOrDefaultAsync();
    }

    public async Task<int> Update(Exercise exercise)
    {
        _coachPlanContext.Exercises.Update(exercise);

        return await _coachPlanContext.SaveChangesAsync();
    }
}
