using CoachPlan.Domain.Dtos;
using CoachPlan.Domain.Entities;

namespace CoachPlan.Domain.Extensions.Dtos;

public static class MuscleDtoExtension
{
    public static Muscle ToModel(this MuscleDto muscleDto)
    {
        return new()
        {
             Id= muscleDto.Id,
             Name= muscleDto.Name
        };
    }

    public static MuscleDto? ToDto(this Muscle muscle)
    {
        return muscle == null ? null :  new()
        {
            Id = muscle.Id,
            Name = muscle.Name
        };
    }

    public static GetMuscleDto? ToGetDto(this Muscle muscle)
    {
        return muscle == null ? null :  new()
        {
            Id = muscle.Id,
            Name = muscle.Name,
            Exercises = muscle.Exercises.AsEnumerable().ToDto()
        };
    }

    public static IEnumerable<MuscleDto> ToDto(this IEnumerable<Muscle> muscles)
    {
        return muscles.Select(m => m.ToDto());
    }

    public static IEnumerable<Muscle> ToModel(this IEnumerable<MuscleDto> muscleDtos)
    {
        return muscleDtos.Select(m => m.ToModel());
    }

    public static IEnumerable<GetMuscleDto> ToGetDto(this IEnumerable<Muscle> muscles)
    {
        return muscles.Select(m => m.ToGetDto());
    }
}
