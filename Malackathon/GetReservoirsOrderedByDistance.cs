using Microsoft.AspNetCore.Http.HttpResults;

namespace Malackathon;

public class GetReservoirsOrderedByDistance(List<GetReservoirsOrderedByDistance.ReservoirBrief> reservoirs)
{
    public async Task<Ok<List<ReservoirBrief>>> Execute(Location location)
    {
        reservoirs.Sort((a, b) => Distance(location, a.location).CompareTo(Distance(location, b.location)));
        return TypedResults.Ok(reservoirs);
    }
    
    public record Location(double x, double y);

    public record ReservoirBrief(string id, string name, Location location, double distance);

    public double Distance(Location a, Location b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }
}