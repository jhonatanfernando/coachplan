using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class CreateMuscleCommand : IRequest<Unit>
{
    private readonly Domain.Entities.Muscle muscle;

    public CreateMuscleCommand(Domain.Entities.Muscle muscle)
    {
        this.muscle = muscle;
    }      

    public class CreateMuscleCommandHandler : IRequestHandler<CreateMuscleCommand, Unit>
    {
        private readonly IMuscleService _muscleService;

        public CreateMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<Unit> Handle(CreateMuscleCommand command, CancellationToken cancellationToken)
        {
            await _muscleService.Create(command.muscle);

            return Unit.Value;
        }
    }
}
