using Grand.Web.Common.Themes;

namespace Theme.HomePage;

public class HomePageThemeView : IThemeView
{
    public string AreaName => "";
    public string ThemeName => "HomePage";

    public ThemeInfo ThemeInfo => new("Home Page theme (beta)", "~/Plugins/Theme.HomePage/Content/theme.jpg",
        "Home Page theme (beta)", false);

    public IEnumerable<string> GetViewLocations()
    {
        return new List<string> {
            "/Views/THomePage/{1}/{0}.cshtml",
            "/Views/THomePage/Shared/{0}.cshtml",
            "/Views/{1}/{0}.cshtml",
            "/Views/Shared/{0}.cshtml"
        };
    }
}