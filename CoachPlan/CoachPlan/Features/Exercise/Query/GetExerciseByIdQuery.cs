namespace CoachPlan.Features.Exercise.Query;

public class GetExerciseByIdQuery : IRequest<ExerciseDto>
{
    private readonly int _id;

    public GetExerciseByIdQuery(int id)
    {
        this._id = id;
    }   
    public class GetMuscleByIdQueryHandler : IRequestHandler<GetExerciseByIdQuery, ExerciseDto>
    {
        private readonly IExerciseService _exerciseService;

        public GetMuscleByIdQueryHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<ExerciseDto> Handle(GetExerciseByIdQuery query, CancellationToken cancellationToken)
        {
            return await _exerciseService.GetById(query._id);
        }
    }
}