using CoachPlan.Domain.Dtos;

namespace CoachPlan.gRPC.Extensions;

public static class Extensins
{
     public static MuscleDto ToDto(this CreateMuscleRequest createMuscleRequest)
     {
        return new()
        {
            Name = createMuscleRequest.Name
        };
     }

     public static ReadMuscleResponse ToGrpcModel(this MuscleDto muscleDto)
     {
        return new()
        {
            Id = muscleDto.Id,
            Name = muscleDto.Name
        };
     }    

     public static GetAllMuscleResponse ToGrpcModel(this IEnumerable<MuscleDto> muscleDtos)
     {
        var items = new GetAllMuscleResponse();

        items.Muscles.AddRange(muscleDtos.Select(c => c.ToGrpcModel()));

        return items;
     }
}