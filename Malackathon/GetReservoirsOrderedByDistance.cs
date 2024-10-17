using Microsoft.AspNetCore.Http.HttpResults;

namespace Malackathon;

public class GetReservoirsOrderedByDistance
{
    private readonly List<Reservoir> reservoirs;

    public GetReservoirsOrderedByDistance(List<Reservoir> reservoirs)
    {
        this.reservoirs = reservoirs;
    }

    public Ok<List<Reservoir>> Execute(Location location)
    {
        reservoirs.Sort((a, b) => Distance(location, a.Location).CompareTo(Distance(location, b.Location)));
        return TypedResults.Ok(reservoirs);
    }
    
    public record Location(double x, double y);

    public record Reservoir(Location Location);

    public double Distance(Location a, Location b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }
}