namespace CoachPlan.Features.Exercise.Command;

public class UpdateExerciseCommand : IRequest<Unit>
{
    private readonly int _id;
    private readonly ExerciseDto _exerciseDto;

    public UpdateExerciseCommand(int id, ExerciseDto exerciseDto)
    {
        _id = id;
        _exerciseDto = exerciseDto;
    }

    public class UpdateMuscleCommandHandler : IRequestHandler<UpdateExerciseCommand, Unit>
    {
        private readonly IExerciseService _exerciseService;

        public UpdateMuscleCommandHandler(IExerciseService exerciseService)
        {
            _exerciseService = exerciseService;
        }

        public async Task<Unit> Handle(UpdateExerciseCommand command, CancellationToken cancellationToken)
        {
            var exercise = await _exerciseService.GetById(command._id);
            if (exercise == null)
                return default;

            exercise.Name = command._exerciseDto.Name;
            exercise.MuscleId = command._exerciseDto.MuscleId;

            await _exerciseService.Update(exercise);

            return Unit.Value;
        }
    }
}