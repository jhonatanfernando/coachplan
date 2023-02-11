namespace CoachPlan.Features.Muscle.Command;

public class UpdateMuscleCommand : IRequest<Unit>
{
    private readonly int _id;
    private readonly MuscleDto _muscleDto;

    public UpdateMuscleCommand(int id, MuscleDto muscleDto)
    {
        _id = id;
        _muscleDto = muscleDto;
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
            var muscle = await _muscleService.GetById(command._id);
            if (muscle == null)
                return default;

            muscle.Name= command._muscleDto.Name; 

            await _muscleService.Update(muscle);

            return Unit.Value;
        }
    }
}