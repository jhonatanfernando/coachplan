using CoachPlan.Features.Exercise.Command;
using CoachPlan.Features.Exercise.Query;

namespace CoachPlan.Features.Exercise;

public static class ExerciseEndpoints
{
    public static void MapExerciseRoutes(this IEndpointRouteBuilder app)
    {
        app.MapGet("/exercises", async (IMediator _mediator) =>
        {
            return await _mediator.Send(new GetAllExercisesQuery());
        });

        app.MapGet("/exercises/{id}", async (IMediator _mediator, int id) =>
        {
            return await _mediator.Send(new GetExerciseByIdQuery(id));
        });

        app.MapPost("/exercises", async (IMediator _mediator, ExerciseDto exerciseDto) =>
        {
            await _mediator.Send(new CreateExerciseCommand(exerciseDto));

            return Results.Created($"/exercises/{exerciseDto.Id}", exerciseDto);
        });

        app.MapPut("/exercises/{id}", async (IMediator _mediator, int id, ExerciseDto exerciseDto) =>
        {
            await _mediator.Send(new UpdateExerciseCommand(id, exerciseDto));

            return Results.NoContent();
        });

        app.MapDelete("/exercises/{id}", async (IMediator _mediator, int id) =>
        {
            await _mediator.Send(new DeleteExerciseCommand(id));

            return Results.Ok();
        });
    }
}
