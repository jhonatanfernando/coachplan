using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class CreateMuscleCommand : IRequest<int>
{
    private readonly Domain.Entities.Muscle muscle;

    public CreateMuscleCommand(Domain.Entities.Muscle muscle)
    {
        this.muscle = muscle;
    }      

    public class CreateMuscleCommandHandler : IRequestHandler<CreateMuscleCommand, int>
    {
        private readonly IMuscleService _muscleService;

        public CreateMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<int> Handle(CreateMuscleCommand command, CancellationToken cancellationToken)
        {
            return await _muscleService.Create(command.muscle);
        }
    }
}
