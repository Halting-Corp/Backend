using FluentAssertions;
using Malackathon;
using static Malackathon.GetReservoirsOrderedByDistance;

namespace MalakathonTest;

public class Tests
{
    private List<ReceivedReservoir> reservoirs =
    [
        new ReceivedReservoir(1, "a", "0", "0"),
        new ReceivedReservoir(2, "b", "3", "4"),
        new ReceivedReservoir(3, "c", "5", "5"),
        new ReceivedReservoir(4, "d", "10", "10"),
        new ReceivedReservoir(5, "e", "1", "1"),
        new ReceivedReservoir(6, "f", "2", "2"),
        new ReceivedReservoir(7, "g", "3", "3"),
    ];

    [Test]
    public async Task GetReservoirsWhichAreAlreadyOrdered()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        var result = (await sut.Execute(new Location(0, 0))).Value!;
        OrderChecker(result, sut, new Location(0, 0));
    }
    
    [Test]
    public async Task GetReservoirsOrderedByDistance()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        var result = (await sut.Execute(new Location(10, 10))).Value!;
        OrderChecker(result, sut, new Location(10, 10));
    }

    [Test]
    public async Task GetReservoirsinOtherOrder()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        var result = (await sut.Execute(new Location(5, 5))).Value!;
        OrderChecker(result, sut, new Location(5, 5));
    }

    private static void OrderChecker(List<ReservoirBrief> result, GetReservoirsOrderedByDistance sut, Location location)
    {
        for (int i = 0; i < result.Count - 1; i++)
        {
            sut.Distance(location, result[i].location).Should().BeLessOrEqualTo(sut.Distance(location, result[i + 1].location));
        }
    }

    [Test]
    public void Distance()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        sut.Distance(new Location(0, 0), new Location(3, 4)).Should().Be(5);
        
    }
}

