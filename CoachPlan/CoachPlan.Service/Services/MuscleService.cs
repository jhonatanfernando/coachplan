using CoachPlan.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace CoachPlan.Service.Services;

public class MuscleService : IMuscleService
{
    private readonly IMuscleRepository _muscleRepository;
    private readonly IDistributedCache _distributedCache;
    private readonly JsonSerializerSettings _jsonSerializerSettings;
    private readonly DistributedCacheEntryOptions expiration;

    public MuscleService(IMuscleRepository muscleRepository, IDistributedCache distributedCache)
    {
        _muscleRepository = muscleRepository;
        _distributedCache = distributedCache;

        _jsonSerializerSettings = new()
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        expiration = new()
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30),
            SlidingExpiration = TimeSpan.FromSeconds(25)
        };
    }   

    public async Task<int> Create(MuscleDto muscleDto)
    {
        return await _muscleRepository.Create(muscleDto.ToModel());
    }

    public async Task<int> Delete(MuscleDto muscleDto)
    {
        return await _muscleRepository.Delete(muscleDto.ToModel());
    }

    public async Task<IEnumerable<GetMuscleDto>> GetAll()
    {
        string key = $"muscle-all";

        string cachedMuscles = await _distributedCache.GetStringAsync(key);

        IEnumerable<Muscle> muscles;

        if (string.IsNullOrEmpty(cachedMuscles))
        {
            muscles = await _muscleRepository.GetAll();

            await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(muscles, _jsonSerializerSettings), expiration);
        }
        else
        {
             muscles = JsonConvert.DeserializeObject<IEnumerable<Muscle>>(cachedMuscles);
        }


        return (await _muscleRepository.GetAll()).ToGetDto();
    }

    public async Task<GetMuscleDto> GetById(int id)
    {
        string key = $"muscle-{id}";

        string cachedMuscle = await _distributedCache.GetStringAsync(key);

        Muscle muscle = null;

        if (string.IsNullOrEmpty(cachedMuscle))
        {
            muscle = await _muscleRepository.GetById(id);

            if (muscle is not null)
            {
                await _distributedCache.SetStringAsync(key, JsonConvert.SerializeObject(muscle, _jsonSerializerSettings), expiration);
            }
        }
        else
        {
            muscle = JsonConvert.DeserializeObject<Muscle>(cachedMuscle);
        }

        return muscle.ToGetDto();
    }

    public async Task<int> Update(MuscleDto muscleDto)
    {
        return await _muscleRepository.Update(muscleDto.ToModel());
    }
}
