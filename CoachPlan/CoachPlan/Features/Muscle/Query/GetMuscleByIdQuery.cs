namespace CoachPlan.Features.Muscle.Query;

public class GetMuscleByIdQuery : IRequest<GetMuscleDto>
{
    private readonly int _id;

    public GetMuscleByIdQuery(int id)
    {
        _id = id;
    }   
    public class GetMuscleByIdQueryHandler : IRequestHandler<GetMuscleByIdQuery, GetMuscleDto>
    {
        private readonly IMuscleService _muscleService;

        public GetMuscleByIdQueryHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<GetMuscleDto> Handle(GetMuscleByIdQuery query, CancellationToken cancellationToken)
        {
            return await _muscleService.GetById(query._id);
        }
    }
}