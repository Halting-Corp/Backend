﻿using System.Text.Json;
using static Malackathon.GetReservoirsOrderedByDistance;

namespace Malackathon;

public class Repository
{
    // get data from https://g1471218befa3c3-malackathon.adb.eu-madrid-1.oraclecloudapps.com/ords/admin/api/embalses
    public static List<ReceivedReservoir>? GetReservoirs()
    {
        var client = new HttpClient();
        var response = client.GetAsync("https://g1471218befa3c3-malackathon.adb.eu-madrid-1.oraclecloudapps.com/ords/admin/api/embalses").Result;
        var json = response.Content.ReadAsStringAsync().Result;
        Console.WriteLine(json);
        var items = JsonSerializer.Deserialize<Dictionary<string, object>>(json)!.GetValueOrDefault("items");
        var reservoirs = JsonSerializer.Deserialize<List<ReceivedReservoir>>(items.ToString());
        return reservoirs;
    }
}