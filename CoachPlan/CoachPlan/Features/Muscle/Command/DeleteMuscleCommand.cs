using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class DeleteMuscleCommand : IRequest<Unit>
{
    private readonly int id;

    public DeleteMuscleCommand(int id)
    {
        this.id = id;
    }   

    public class DeleteMuscleCommandHandler : IRequestHandler<DeleteMuscleCommand, Unit>
    {
        private readonly IMuscleService _muscleService;

        public DeleteMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<Unit> Handle(DeleteMuscleCommand command, CancellationToken cancellationToken)
        {
            var muscle = await _muscleService.GetById(command.id);
            if (muscle == null)
                return default;

            await _muscleService.Delete(muscle);

            return Unit.Value;
        }
    }
}