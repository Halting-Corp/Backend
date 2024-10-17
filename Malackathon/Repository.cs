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
        var list = JsonSerializer.Deserialize<List<object>>(items.ToString());
        if (list.Count == 0) return null;
        var reservoir = JsonSerializer.Deserialize<ReceivedReservoir>(list[0].ToString());
        Console.WriteLine(reservoir);
        return reservoir;
        
    }

    public static async Task<int> GetWater(int id)
    {
        var client = new HttpClient();
        var response = await client.GetAsync($"https://g1471218befa3c3-malackathon.adb.eu-madrid-1.oraclecloudapps.com/ords/admin/api/agua-embalse/{id}");
        var json = await response.Content.ReadAsStringAsync();
        var items = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!.GetValueOrDefault("items");
        var water = JsonSerializer.Deserialize<List<Dictionary<string, int>>>(items.ToString())[0].GetValueOrDefault("agua_actual");
        return water;
    }
}