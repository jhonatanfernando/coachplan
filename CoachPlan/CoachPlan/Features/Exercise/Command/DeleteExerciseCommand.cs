namespace CoachPlan.Features.Exercise.Command;

public class DeleteExerciseCommand : IRequest<Unit>
{
    private readonly int _id;

    public DeleteExerciseCommand(int id)
    {
        _id = id;
    }   

    public class DeleteMuscleCommandHandler : IRequestHandler<DeleteExerciseCommand, Unit>
    {
        private readonly IExerciseService _exerciseService;

        public DeleteMuscleCommandHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<Unit> Handle(DeleteExerciseCommand command, CancellationToken cancellationToken)
        {
            var execise = await _exerciseService.GetById(command._id);
            if (execise == null)
                return default;

            await _exerciseService.Delete(execise);

            return Unit.Value;
        }
    }
}