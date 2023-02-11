using CoachPlan.Features.Muscle.Command;
using CoachPlan.Features.Muscle.Query;

namespace CoachPlan.Features.Muscle
{
    public static class MuscleEndpoints
    {
        public static void MapMuscleRoutes(this IEndpointRouteBuilder app)
        {
            app.MapGet("/muscles", async (IMediator _mediator) =>
            {
                return await _mediator.Send(new GetAllMusclesQuery());
            });

            app.MapGet("/muscles/{id}", async (IMediator _mediator, int id) =>
            {
                return await _mediator.Send(new GetMuscleByIdQuery(id));
            });

            app.MapPost("/muscles", async (IMediator _mediator, MuscleDto muscleDto) =>
            {
                await _mediator.Send(new CreateMuscleCommand(muscleDto));

                return Results.Created($"/muscles/{muscleDto.Id}", muscleDto);
            });

            app.MapPut("/muscles/{id}", async (IMediator _mediator, int id, MuscleDto muscleDto) =>
            {
                await _mediator.Send(new UpdateMuscleCommand(id, muscleDto));

                return Results.NoContent();
            });

            app.MapDelete("/muscles/{id}", async (IMediator _mediator, int id) =>
            {
                await _mediator.Send(new DeleteMuscleCommand(id));

                return Results.Ok();
            });
        }
    }
}
