using System.Text.Json;
using static GetReservoirInfo;
using static Malackathon.GetReservoirsOrderedByDistance;

namespace Malackathon;

public class Repository
{
    public static async Task<List<ReceivedReservoirBrief>?> GetReservoirs()
    {
        var client = new HttpClient();
        var response = await client.GetAsync("https://g1471218befa3c3-malackathon.adb.eu-madrid-1.oraclecloudapps.com/ords/admin/api/embalses");
        var json = await response.Content.ReadAsStringAsync();
        var items = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!.GetValueOrDefault("items");
        var reservoirs = JsonSerializer.Deserialize<List<ReceivedReservoirBrief>>(items.ToString());
        return reservoirs;
    }

    public static async Task<ReceivedReservoir?> GetReservoir(int id)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://g1471218befa3c3-malackathon.adb.eu-madrid-1.oraclecloudapps.com/ords/admin/api/embalse/{id}");
        var json = await response.Content.ReadAsStringAsync();
        var items = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!.GetValueOrDefault("items");
        var dfasdfa = JsonSerializer.Deserialize<List<object>>(items.ToString());
        if (dfasdfa.Count == 0) return null;
        Console.WriteLine(dfasdfa);
        Console.WriteLine(dfasdfa[0]);
        var reservoir = JsonSerializer.Deserialize<ReceivedReservoir>(dfasdfa[0].ToString());
        Console.WriteLine(reservoir);
        return reservoir;
        
    }
}