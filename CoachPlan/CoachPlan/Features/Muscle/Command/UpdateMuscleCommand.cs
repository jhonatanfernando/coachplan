using CoachPlan.Domain.Services;
using MediatR;

namespace CoachPlan.Features.Muscle.Command;

public class UpdateMuscleCommand : IRequest<int>
{
    private readonly int id;
    private readonly Domain.Entities.Muscle muscle;

    public UpdateMuscleCommand(int id, Domain.Entities.Muscle muscle)
    {
        this.id = id;
        this.muscle = muscle;
    }

    public class UpdateMuscleCommandHandler : IRequestHandler<UpdateMuscleCommand, int>
    {
        private readonly IMuscleService _muscleService;

        public UpdateMuscleCommandHandler(IMuscleService muscleService)
        {
            _muscleService = muscleService;
        }

        public async Task<int> Handle(UpdateMuscleCommand command, CancellationToken cancellationToken)
        {
            var muscle = await _muscleService.GetById(command.id);
            if (muscle == null)
                return default;

            muscle.Name= command.muscle.Name; 

            return await _muscleService.Update(muscle);
        }
    }
}