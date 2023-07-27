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
}
