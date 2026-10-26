using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;

namespace MobileTests.pages;

public class ClockPage
{
    private readonly AndroidDriver _driver;
    public ClockPage(AndroidDriver driver) => _driver = driver;
    protected IWebElement TitleElement =>
        _driver.FindElement(MobileBy.Id("com.google.android.deskclock:id/action_bar_title"));
    public string TitleText => TitleElement.Text;
    public void OpenSection(string sectionName)
    {
        if (TitleText != sectionName)
        {
            _driver.FindElement(MobileBy.AccessibilityId(sectionName)).Click();
        }
    }
}