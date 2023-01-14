using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class DeleteMuscleCommand : IRequest<int>
{
    private readonly int id;

    public DeleteMuscleCommand(int id)
    {
        this.id = id;
    }   

    public class DeleteMuscleCommandHandler : IRequestHandler<DeleteMuscleCommand, int>
    {
        private readonly IMuscleService _muscleService;

        public DeleteMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<int> Handle(DeleteMuscleCommand command, CancellationToken cancellationToken)
        {
            var muscle = await _muscleService.GetById(command.id);
            if (muscle == null)
                return default;

            return await _muscleService.Delete(muscle);
        }
    }
}