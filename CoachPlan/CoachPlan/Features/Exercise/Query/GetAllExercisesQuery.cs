namespace CoachPlan.Features.Exercise.Query;

public class GetAllExercisesQuery : IRequest<IEnumerable<ExerciseDto>>
{
    public class GetAllMusclesQueryHandler : IRequestHandler<GetAllExercisesQuery, IEnumerable<ExerciseDto>>
    {
        private readonly IExerciseService _exerciseService;

        public GetAllMusclesQueryHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<IEnumerable<ExerciseDto>> Handle(GetAllExercisesQuery query, CancellationToken cancellationToken)
        {
            return await _exerciseService.GetAll();
        }
    }
}
