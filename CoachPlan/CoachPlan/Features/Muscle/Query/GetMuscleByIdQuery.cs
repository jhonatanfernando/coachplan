using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Query;

public class GetMuscleByIdQuery : IRequest<Domain.Entities.Muscle>
{
    private readonly int id;

    public GetMuscleByIdQuery(int id)
    {
        this.id = id;
    }   
    public class GetMuscleByIdQueryHandler : IRequestHandler<GetMuscleByIdQuery, Domain.Entities.Muscle>
    {
        private readonly IMuscleService _muscleService;

        public GetMuscleByIdQueryHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<Domain.Entities.Muscle> Handle(GetMuscleByIdQuery query, CancellationToken cancellationToken)
        {
            return await _muscleService.GetById(query.id);
        }
    }
}