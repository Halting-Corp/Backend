using Malackathon;
using static Malackathon.GetReservoirsOrderedByDistance;

public class GetReservoirInfo
{
    public async Task<Reservoir?> Execute(int id)
    {
        var received = await Repository.GetReservoir(id);
        if(received == null) return null;
        return new Reservoir(
            received.codigo,
            received.nombre,
            new Location(Convert.ToDouble(received.x.Replace(',','.')), Convert.ToDouble(received.y.Replace(',','.'))),
            // new Location(0,0),
            received.demarc,
            received.cauce,
            received.provincia,
            received.ccaa,
            received.tipo,
            received.cota_coron,
            received.alt_cimien,
            received.informe,
            received.agua_fk,
            received.agua_total,
            received.electrico_flag
        );
    }

    public record Reservoir(
        int id,
        string name,
        Location location,
        string demarc,
        string cauce,
        string provincia,
        string ccaa,
        string tipo,
        string? cotaCoron,
        string? altCimien,
        string informe,
        int aguaFk,
        int aguaTotal,
        int electricoFlag
    );
        
        
    public record ReceivedReservoir(
        int codigo,
        string nombre,
        string x,
        string y,
        string demarc,
        string cauce,
        string provincia,
        string ccaa,
        string tipo,
        string? cota_coron, 
        string? alt_cimien, 
        string informe,
        int agua_fk,
        int agua_total,
        int electrico_flag
    );
}