using CodeCool.CrashTest.Model;
using CodeCool.CrashTest.Service;

namespace CodeCool.CrashTesterTest;

public class CrashTesterTest
{
    private readonly CrashTester _crashTester;
    
    public CrashTesterTest()
    {
        int minimumSpeedToOpenTheAirbag = 30;
        _crashTester = new CrashTester(minimumSpeedToOpenTheAirbag);
    }
    [Test]
    public void TestCrash_BelowMinimumSpeedNoSeatTaken_NoAirbagsOpen()
    {
        HashSet<Seat> seats = new HashSet<Seat>();
        for (int i = 0; i < 4; i++)
        {
            Seat newSeat = new Seat(false, false);
            seats.Add(newSeat);
        }

        int airbagsOpen = 0;
        Car carToTest = new Car(29, seats);

        _crashTester.TestCrash(carToTest);

        foreach (var seat in carToTest.Seats)
        {
            if (seat.IsAirbagOpen)
            {
                airbagsOpen += 1;
            }
        }
        Assert.That(airbagsOpen, Is.EqualTo(0));

    }
    [Test]
    public void TestCrash_BelowMinimumSpeedOneSeatIsTaken_NoAirbagsOpen()
    {
        HashSet<Seat> seats = new HashSet<Seat>();
        for (int i = 0; i < 4; i++)
        {
            Seat newSeat = i == 0 ? new Seat(true, false) : new Seat(false, false);
            seats.Add(newSeat);
        }

        int airbagsOpen = 0;
        Car carToTest = new Car(29, seats);

        _crashTester.TestCrash(carToTest);

        foreach (var seat in carToTest.Seats)
        {
            if (seat.IsAirbagOpen)
            {
                airbagsOpen += 1;
            }
        }
        Assert.That(airbagsOpen, Is.EqualTo(0));
    }
    [Test]
    public void TestCrash_AboveMinSpeedNoSeatIsTaken_NoAirbagsOpen()
    {
        HashSet<Seat> seats = new HashSet<Seat>();
        for (int i = 0; i < 4; i++)
        {
            Seat newSeat = new Seat(false, false);
            seats.Add(newSeat);
        }

        int airbagsOpen = 0;
        Car carToTest = new Car(30, seats);

        _crashTester.TestCrash(carToTest);

        foreach (var seat in carToTest.Seats)
        {
            if (seat.IsAirbagOpen)
            {
                airbagsOpen += 1;
            }
        }
        Assert.That(airbagsOpen, Is.EqualTo(0));
    }
    [Test]
    public void TestCrash_AboveMinSpeedOneSeatIsTaken_AirbagsDoOpen()
    {
        HashSet<Seat> seats = new HashSet<Seat>();
        for (int i = 0; i < 4; i++)
        {
            Seat newSeat = i == 0 ? new Seat(true, false) : new Seat(false, false);
            seats.Add(newSeat);
        }

        int airbagsOpen = 0;
        Car carToTest = new Car(30, seats);

        _crashTester.TestCrash(carToTest);

        foreach (var seat in carToTest.Seats)
        {
            if (seat.IsAirbagOpen)
            {
                airbagsOpen += 1;
            }
        }
        Assert.That(airbagsOpen, Is.EqualTo(1));
    }
    [Test]
    public void TestCrash_AboveMinSpeedTwoSeats_ForTakenSeatAirbagDoOpenForEmptySeatAirbagDoNotOpen()
    {
        HashSet<Seat> seats = new HashSet<Seat>();
        for (int i = 0; i < 2; i++)
        {
            Seat newSeat = i == 0 ? new Seat(true, false) : new Seat(false, false);
            seats.Add(newSeat);
        }

        int airbagOpenForTakenSeat = 0;
        int airbagClosedForEmptySeat = 0;
        Car carToTest = new Car(30, seats);

        _crashTester.TestCrash(carToTest);

        foreach (var seat in carToTest.Seats)
        {
            if (seat.IsUsed && seat.IsAirbagOpen)
            {
                airbagOpenForTakenSeat += 1;
            } else if (!seat.IsUsed && !seat.IsAirbagOpen)
            {
                airbagClosedForEmptySeat += 1;
            }
        }
        Assert.That(airbagOpenForTakenSeat, Is.EqualTo(1));
        Assert.That(airbagClosedForEmptySeat, Is.EqualTo(1));
    }
}
