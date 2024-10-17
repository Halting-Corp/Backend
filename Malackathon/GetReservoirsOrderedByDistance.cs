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
        var briefs = reservoirs.Select(r =>
            {
                var location2 = new Location(double.Parse(r.x.Replace(",", ".")), double.Parse(r.y.Replace(",", ".")));
                return new ReservoirBrief(r.codigo, r.nombre, location2,
                    Distance(location, location2));
            })
            .ToList();
        briefs.Sort((a, b) => a.distance.CompareTo(b.distance));
        return TypedResults.Ok(briefs);
    }
    
    public record Location(double x, double y);

    public record ReservoirBrief(int id, string name, Location location, double distance);
    public record ReceivedReservoir(int codigo, string nombre, string x, string y);

    public double Distance(Location a, Location b)
    {
        return Math.Sqrt(Math.Pow(a.x - b.x, 2) + Math.Pow(a.y - b.y, 2));
    }
}