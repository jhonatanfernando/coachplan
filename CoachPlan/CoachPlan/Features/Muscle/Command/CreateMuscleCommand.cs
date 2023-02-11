namespace CoachPlan.Features.Muscle.Command;

public class CreateMuscleCommand : IRequest<Unit>
{
    private readonly MuscleDto _muscleDto;

    public CreateMuscleCommand(MuscleDto muscleDto)
    {
        _muscleDto = muscleDto;
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
            await _muscleService.Create(command._muscleDto);

            return Unit.Value;
        }
    }
}
