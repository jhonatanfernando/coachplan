namespace CoachPlan.Domain.Entities;

public class Exercise
{
    public int Id { get; set; }

    public string Name { get; set; }

    public int MuscleId { get; set; }
    public virtual Muscle Muscle { get; set; }
}
