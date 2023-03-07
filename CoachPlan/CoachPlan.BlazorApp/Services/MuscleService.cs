using CoachPlan.Domain.Dtos;
using CoachPlan.Domain.Services;
using System.Net.Http.Json;

namespace CoachPlan.BlazorApp.Services;

public class MuscleService : IMuscleService
{
    private readonly HttpClient httpClient;

    public MuscleService(HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }   

    public Task<int> Create(MuscleDto muscleDto)
    {
        throw new NotImplementedException();
    }

    public Task<int> Delete(MuscleDto muscleDto)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<GetMuscleDto>> GetAll()
    {
        return await httpClient.GetFromJsonAsync<GetMuscleDto[]>("/muscles");
    }

    public Task<GetMuscleDto> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<int> Update(MuscleDto muscleDto)
    {
        throw new NotImplementedException();
    }
}
