namespace CoachPlan.Features.Muscle.Command;

public class DeleteMuscleCommand : IRequest<Unit>
{
    private readonly int _id;

    public DeleteMuscleCommand(int id)
    {
        _id = id;
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
            var muscle = await _muscleService.GetById(command._id);
            if (muscle == null)
                return default;

            await _muscleService.Delete(muscle);

            return Unit.Value;
        }
    }
}