using Microsoft.AspNetCore.Http.HttpResults;

namespace Malackathon;

public class GetReservoirsOrderedByDistance
{
    private List<ReceivedReservoir> reservoirs;

    public GetReservoirsOrderedByDistance(List<ReceivedReservoir> reservoirs)
    {
        this.reservoirs = reservoirs;
    }

    public GetReservoirsOrderedByDistance() : this(Repository.GetReservoirs()!){}
    
    public async Task<Ok<List<ReservoirBrief>>> Execute(Location location)
    {
        var briefs = reservoirs.Select(r => new ReservoirBrief(r.code, r.name, new Location(r.x, r.y), Distance(location, new Location(r.x, r.y))))
            .ToList();
        briefs.Sort((a, b) => a.distance.CompareTo(b.distance));
        return TypedResults.Ok(briefs);
    }
    
    public record Location(double x, double y);

    public record ReservoirBrief(string id, string name, Location location, double distance);
    public record ReceivedReservoir(string code, string name, double x, double y);

    public double Distance(Location a, Location b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }
}