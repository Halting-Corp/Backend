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
        sut.Execute(new Location(10, 10)).Value.Should().BeEquivalentTo(reversed, options => options.WithStrictOrdering());
    }
}

