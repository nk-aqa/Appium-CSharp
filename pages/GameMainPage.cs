using AltTester.AltTesterSDK.Driver;

namespace MobileTests.pages;

public class GameMainPage
{
    private readonly AltDriver _altDriver;

    public GameMainPage(AltDriver altDriver) => _altDriver = altDriver;

    public AltObject StartButton =>
        _altDriver.FindObject(By.NAME, "StartButton");

    public AltObject StartText =>
        _altDriver.FindObject(By.TEXT, "START");

    public bool isDisplayed()
    {
        if (StartButton != null && StartText != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}