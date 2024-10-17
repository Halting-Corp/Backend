using FluentAssertions;
using Malackathon;
using static Malackathon.GetReservoirsOrderedByDistance;

namespace MalakathonTest;

public class Tests
{
    private List<ReservoirBrief> reservoirs =
    [
        new ReservoirBrief("1", "reservoir1", new Location(0, 0), 0),
        new ReservoirBrief("2", "reservoir2", new Location(1, 1), 0),
        new ReservoirBrief("3", "reservoir3", new Location(2, 2), 0),
        new ReservoirBrief("4", "reservoir4", new Location(3, 3), 0),
        new ReservoirBrief("5", "reservoir5", new Location(4, 4), 0),
        new ReservoirBrief("6", "reservoir6", new Location(5, 5), 0),
        new ReservoirBrief("7", "reservoir7", new Location(6, 6), 0),
        new ReservoirBrief("8", "reservoir8", new Location(7, 7), 0),
        new ReservoirBrief("9", "reservoir9", new Location(8, 8), 0),
        new ReservoirBrief("10", "reservoir10", new Location(9, 9), 0),
        new ReservoirBrief("10", "reservoir10", new Location(9, 9), 0),
        new ReservoirBrief("10", "reservoir10", new Location(9, 9), 0),
    ];

    [Test]
    public async Task GetReservoirsWhichAreAlreadyOrdered()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        (await sut.Execute(new Location(0, 0))).Value.Should().BeEquivalentTo(reservoirs, options => options.WithStrictOrdering());
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

