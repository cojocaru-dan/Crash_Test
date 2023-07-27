using CodeCool.CrashTest.Model;

namespace CodeCool.CrashTest.Service;

public class CrashTester
{
    private readonly int _minimumSpeedToOpenTheAirbag;

    public CrashTester(int minimumSpeedToOpenTheAirbag)
    {
        _minimumSpeedToOpenTheAirbag = minimumSpeedToOpenTheAirbag;
    }

    public void TestCrash(Car car)
    {
        if (car.Speed < _minimumSpeedToOpenTheAirbag)
        {
            return;
        }

        HashSet<Seat> seats = car.Seats;
        foreach (Seat seat in seats)
        {
            if (seat.IsUsed)
            {
                seat.IsAirbagOpen = true;
            }
        }
    }
}
