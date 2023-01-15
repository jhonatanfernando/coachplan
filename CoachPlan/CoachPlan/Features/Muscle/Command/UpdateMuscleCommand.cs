using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class UpdateMuscleCommand : IRequest<Unit>
{
    private readonly int id;
    private readonly Domain.Entities.Muscle muscle;

    public UpdateMuscleCommand(int id, Domain.Entities.Muscle muscle)
    {
        this.id = id;
        this.muscle = muscle;
    }

    public class UpdateMuscleCommandHandler : IRequestHandler<UpdateMuscleCommand, Unit>
    {
        private readonly IMuscleService _muscleService;

        public UpdateMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<Unit> Handle(UpdateMuscleCommand command, CancellationToken cancellationToken)
        {
            var muscle = await _muscleService.GetById(command.id);
            if (muscle == null)
                return default;

            muscle.Name= command.muscle.Name; 

            await _muscleService.Update(muscle);

            return Unit.Value;
        }
    }
}