namespace CoachPlan.Features.Muscle.Query;

public class GetAllMusclesQuery : IRequest<IEnumerable<GetMuscleDto>>
{
    public class GetAllMusclesQueryHandler : IRequestHandler<GetAllMusclesQuery, IEnumerable<GetMuscleDto>>
    {
        private readonly IMuscleService _muscleService;

        public GetAllMusclesQueryHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<IEnumerable<GetMuscleDto>> Handle(GetAllMusclesQuery query, CancellationToken cancellationToken)
        {
            return await _muscleService.GetAll();
        }
    }
}
