using Malackathon;

public class GetReservoirWater
{
    public async Task<int> Execute(int id)
    {
        return await Repository.GetWater(id);
    }
}