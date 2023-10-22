using CoachPlan.gRPC;
using Grpc.Core;
using CoachPlan.Domain.Services;
using CoachPlan.Domain.Dtos;
using CoachPlan.gRPC.Extensions;

namespace CoachPlan.gRPC.Services;

public class CoachPlanService : CoachPlan.CoachPlanBase
{
    private readonly IMuscleService _muscleService;

    public CoachPlanService(IMuscleService muscleService)
    {
        _muscleService = muscleService;
    }

     public override async Task<ReadMuscleResponse> CreateMuscle(CreateMuscleRequest request, ServerCallContext context)
     {
        if(string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Name))
            throw new RpcException(new Status(StatusCode.InvalidArgument, "The property 'Name' is required."));

        MuscleDto dto = request.ToDto();

        var id = await _muscleService.Create(dto);

        var muscleDto = await _muscleService.GetById(id);

        var response = muscleDto.ToGrpcModel();

        return response;
     }

     public override async Task<GetAllMuscleResponse> ListMuscle(GetAllMuscleRequest request, ServerCallContext context)
     {
        var muscles = await _muscleService.GetAll();

        var response = muscles.ToGrpcModel();

        return response;
     }

     public override async Task<ReadMuscleResponse> ReadMuscle(ReadMuscleRequest request, ServerCallContext context)
     {
         var muscle = await _muscleService.GetById(request.Id);

         if(muscle == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));


         return muscle.ToGrpcModel();
     }

      public override async Task<ReadMuscleResponse> UpdateMuscle(UpdateMuscleRequest request, ServerCallContext context)
      {
         if(string.IsNullOrEmpty(request.Name) || string.IsNullOrEmpty(request.Name))
            throw new RpcException(new Status(StatusCode.InvalidArgument, "The property 'Name' is required."));

         var muscle = await _muscleService.GetById(request.Id);

         if(muscle == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

         muscle.Name = request.Name;

         await _muscleService.Update(muscle); 

         return muscle.ToGrpcModel();
      }

      public override async Task<DeleteMuscleResponse> DeleteMuscle(DeleteMuscleRequest request, ServerCallContext context)
      {
         var muscle = await _muscleService.GetById(request.Id);

         if(muscle == null)
            throw new RpcException(new Status(StatusCode.NotFound, "Not Found"));

         await _muscleService.Delete(muscle);

         return new DeleteMuscleResponse()
         {
            Id = muscle.Id
         };
      }
}
