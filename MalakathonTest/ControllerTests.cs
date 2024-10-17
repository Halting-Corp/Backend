using FluentAssertions;
using Malackathon;
using static Malackathon.GetReservoirsOrderedByDistance;

namespace MalakathonTest;

public class Tests
{
    private List<Reservoir> reservoirs =
    [
        new(new Location(0, 0)),
        new(new Location(1, 1)),
        new(new Location(2, 2)),
        new(new Location(3, 3)),
        new(new Location(4, 4)),
        new(new Location(5, 5)),
        new(new Location(6, 6)),
        new(new Location(7, 7)),
        new(new Location(8, 8)),
        new(new Location(9, 9))
    ];

    [Test]

    public void GetReservoirsWhichAreAlreadyOrdered()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        sut.Execute(new Location(0, 0)).Value.Should().BeEquivalentTo(reservoirs, options => options.WithStrictOrdering());
    }
    
    [Test]
    public void GetReservoirsOrderedByDistance()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        var reversed = reservoirs.Reverse<Reservoir>().ToList();
        var result = sut.Execute(new Location(10, 10)).Value!;
        OrderChecker(result, sut, new Location(10, 10));
    }

    [Test]
    public void GetReservoirsinOtherOrder()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        var result = sut.Execute(new Location(5, 5)).Value!;
        OrderChecker(result, sut, new Location(5, 5));
    }

    private static void OrderChecker(List<Reservoir> result, GetReservoirsOrderedByDistance sut, Location location)
    {
        for (int i = 0; i < result.Count - 1; i++)
        {
            sut.Distance(location, result[i].Location).Should().BeLessOrEqualTo(sut.Distance(location, result[i + 1].Location));
        }
    }

    [Test]
    public void Distance()
    {
        var sut = new GetReservoirsOrderedByDistance(reservoirs);
        sut.Distance(new Location(0, 0), new Location(3, 4)).Should().Be(5);
        
    }
}

