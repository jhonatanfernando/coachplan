using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Query;

public class GetAllMusclesQuery : IRequest<IEnumerable<Domain.Entities.Muscle>>
{
    public class GetAllMusclesQueryHandler : IRequestHandler<GetAllMusclesQuery, IEnumerable<Domain.Entities.Muscle>>
    {
        private readonly IMuscleService _muscleService;

        public GetAllMusclesQueryHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<IEnumerable<Domain.Entities.Muscle>> Handle(GetAllMusclesQuery query, CancellationToken cancellationToken)
        {
            return await _muscleService.GetAll();
        }
    }
}
