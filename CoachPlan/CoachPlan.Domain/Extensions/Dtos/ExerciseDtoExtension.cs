using CoachPlan.Domain.Dtos;
using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Extensions.Dtos;

public static class ExerciseDtoExtension
{
    public static Exercise ToModel(this ExerciseDto exerciseDto)
    {
        return new()
        {
            Id = exerciseDto.Id,
            Name = exerciseDto.Name,
            MuscleId= exerciseDto.MuscleId
        };
    }

    public static ExerciseDto ToDto(this Exercise exercise)
    {
        return new()
        {
            Id = exercise.Id,
            Name = exercise.Name,
            MuscleId = exercise.MuscleId
        };
    }

    public static IEnumerable<ExerciseDto> ToDto(this IEnumerable<Exercise> exercises)
    {
        return exercises.Select(m => m.ToDto());
    }

    public static IEnumerable<Exercise> ToModel(this IEnumerable<ExerciseDto> exerciseDtos)
    {
        return exerciseDtos.Select(m => m.ToModel());
    }
}
