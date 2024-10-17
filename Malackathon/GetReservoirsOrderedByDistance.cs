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
        return TypedResults.Ok(reservoirs);
    }
    
    public record Location(double x, double y);

    public record Reservoir(Location Location);
}