namespace CoachPlan.Domain.Entities;

public class Muscle
{
    public int Id { get; set; }

    public string Name { get; set; }

    public virtual List<Exercise> Exercises { get; set; }
}
