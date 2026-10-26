using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using AltTester.AltTesterSDK.Driver;

namespace MobileTests.pages;

public abstract class BasePage
{
    protected const string Udid = "58110DLCH005LJ";
    protected const string AppPackage = "com.DefaultCompany.TrashCatMobile";
    protected AndroidDriver _driver = null!;
    protected AltDriver _altDriver = null!;

    [SetUp]
    public void SetUp()
    {
        var options = new AppiumOptions
        {
            PlatformName = "Android",
            AutomationName = "UiAutomator2",
            DeviceName = Udid
        };

        options.AddAdditionalAppiumOption("appium:udid", Udid);
        options.AddAdditionalAppiumOption("appium:noReset", true);
        options.AddAdditionalAppiumOption("appium:newCommandTimeout", 120);
        options.AddAdditionalAppiumOption("appium:autoGrantPermissions", true);

        _driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/"), options, TimeSpan.FromSeconds(180));
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        _driver.ActivateApp("com.google.android.deskclock");
        Assert.That(_driver.CurrentPackage, Is.EqualTo("com.google.android.deskclock"));
    }

    [TearDown]
    public void TearDown()
    {
        CloseGameApp();
        _driver?.TerminateApp("com.google.android.deskclock");
        _driver?.Quit();
        _driver?.Dispose();
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        _altDriver?.Stop();
    }

    protected void ActivateGameApp()
    {
        _driver.ActivateApp(AppPackage);
        Thread.Sleep(5000);
        _altDriver ??= new AltDriver(host: "127.0.0.1", port: 13000);
    }

    protected void CloseGameApp() =>
        _driver.TerminateApp(AppPackage);
}