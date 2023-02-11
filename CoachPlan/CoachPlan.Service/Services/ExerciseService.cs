namespace CoachPlan.Service.Services;

public class ExerciseService : IExerciseService
{
    private readonly IExerciseRepository _exerciseRepository;

    public ExerciseService(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }
    public async Task<int> Create(ExerciseDto exerciseDto)
    {
        return await _exerciseRepository.Create(exerciseDto.ToModel());
    }

    public async Task<int> Delete(ExerciseDto exerciseDto)
    {
        return await _exerciseRepository.Delete(exerciseDto.ToModel());
    }

    public async Task<IEnumerable<ExerciseDto>> GetAll()
    {
        return (await _exerciseRepository.GetAll()).ToDto();
    }

    public async Task<ExerciseDto> GetById(int id)
    {
        return (await _exerciseRepository.GetById(id)).ToDto();
    }

    public async Task<int> Update(ExerciseDto exerciseDto)
    {
        return await _exerciseRepository.Update(exerciseDto.ToModel());
    }
}
