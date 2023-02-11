namespace CoachPlan.Domain.Dtos;

public class MuscleDto
{    public int Id { get; set; }
    public string Name { get; set; }
}

public class GetMuscleDto : MuscleDto
{
   public IEnumerable<ExerciseDto> Exercises { get; set; }
}
