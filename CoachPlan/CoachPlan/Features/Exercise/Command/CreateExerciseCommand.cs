namespace CoachPlan.Features.Exercise.Command;

public class CreateExerciseCommand : IRequest<Unit>
{
    private readonly ExerciseDto _exerciseDto;

    public CreateExerciseCommand(ExerciseDto exerciseDto)
    {
        _exerciseDto = exerciseDto;
    }      

    public class CreateMuscleCommandHandler : IRequestHandler<CreateExerciseCommand, Unit>
    {
        private readonly IExerciseService _exerciseService;

        public CreateMuscleCommandHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<Unit> Handle(CreateExerciseCommand command, CancellationToken cancellationToken)
        {
            await _exerciseService.Create(command._exerciseDto);

            return Unit.Value;
        }
    }
}
