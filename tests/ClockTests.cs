using MobileTests.pages;

namespace MobileTests.tests;

[TestFixture]
public class ClockTests : BasePage
{
    private ClockPage clockPage = null!;
    private GameMainPage gameMainPage = null!;

    [SetUp]
    public void PageSetUp()
    {
        clockPage = new ClockPage(_driver);
    }

    [Test, Order(1)]
    public void OpenAlarmSection()
    {
        clockPage.OpenSection("Alarms");
        Assert.That(clockPage.TitleText, Is.EqualTo("Alarms"));
    }

    [Test, Order(2)]
    public void OpenWorldClockSection()
    {
        clockPage.OpenSection("World clock");
        Assert.That(clockPage.TitleText, Is.EqualTo("World clock"));
    }

    [Test, Order(3)]
    public void OpenTimersSection()
    {
        clockPage.OpenSection("Timers");
        Assert.That(clockPage.TitleText, Is.EqualTo("Timers"));
    }

    [Test, Order(4)]
    public void OpenStopwatchSection()
    {
        clockPage.OpenSection("Stopwatch");
        Assert.That(clockPage.TitleText, Is.EqualTo("Stopwatch"));
    }

    [Test, Order(5)]
    public void OpenBedtimeSection()
    {
        clockPage.OpenSection("Bedtime");
        Assert.That(clockPage.TitleText, Is.EqualTo("Bedtime"));
        ActivateGameApp();
        gameMainPage = new GameMainPage(_altDriver);
        Assert.That(gameMainPage.isDisplayed(), Is.True);
    }
}