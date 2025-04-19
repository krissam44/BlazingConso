using Microsoft.AspNetCore.Components;
using MudBlazor;
using MudBlazor.Utilities;

namespace BlazingConso.Components.Layout;

public partial class MainLayout
{
    [Inject] private NavigationManager Nav { get; set; } = default!;

    private bool open = true;
    private bool _drawerOpen = true;
    private bool _isDarkMode = false;
    private MudTheme? theme = null;

    protected override void OnInitialized()
    {
        base.OnInitialized();

        theme = new()
        {
            PaletteLight = CrispyThemeSunsetSerenade.Theme.PaletteLight,
            PaletteDark = CrispyThemeSunsetSerenade.Theme.PaletteDark,
            LayoutProperties = new LayoutProperties()
        };
    }

    private bool _mini = true;

    private void OnHoverEnter()
    {
        _mini = false; // développe
    }

    private void OnHoverLeave()
    {
        _mini = true; // réduit
    }

    private bool _miniVariant = true;

    private void ToggleMiniVariant()
    {
        _miniVariant = !_miniVariant;
    }

    private void OnDrawerMouseEnter()
    {
        _miniVariant = false; // développe le menu au survol
    }

    private void OnDrawerMouseLeave()
    {
        _miniVariant = true; // referme le menu quand la souris sort
    }

    private void DrawerToggle()
    {
        _drawerOpen = !_drawerOpen;
    }

    private void DarkModeToggle()
    {
        _isDarkMode = !_isDarkMode;
    }

    private void DrawerClose()
    {
        _drawerOpen = false;
    }

    private void DrawerAutoClose()
    {
        // Se ferme automatiquement si on sort du menu (drawer)
        _drawerOpen = false;
    }

    private void HandleBodyMouseOver()
    {
        if (_drawerOpen)
        {
            _drawerOpen = false;
        }
    }

    public class CrispyThemeSunsetSerenade
    {
        public static MudTheme Theme
        {
            get
            {
                return new MudTheme
                {
                    PaletteLight = new MudBlazor.PaletteLight
                    {
                        AppbarBackground = new MudColor("#003D59"),
                        Primary = new MudColor("#003D59"),
                        Secondary = new MudColor("#013243"),
                        Tertiary = new MudColor("#007BA7"),
                        Info = new MudColor("#030dd3"),
                        Success = new MudColor("#b823cc"),
                        Warning = new MudColor("#deac3a"),
                        Error = new MudColor("#FF0000"),
                        Dark = new MudColor("#010B13"),
                    },
                    PaletteDark = new MudBlazor.PaletteDark
                    {
                        AppbarBackground = new MudColor("#CC4A43"),
                        Primary = new MudColor("#CC4A43"),
                        Secondary = new MudColor("#CC5656"),
                        Tertiary = new MudColor("#CC8164"),
                        Info = new MudColor("#6B9AC3"),
                        Success = new MudColor("#2C8C59"),
                        Warning = new MudColor("#B2861C"),
                        Error = new MudColor("#8F1B1B"),
                        Dark = new MudColor("#000000"),
                    },

                    Typography = new Typography
                    {
                        Default = new DefaultTypography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = ".875rem",
                            FontWeight = "400",
                            LineHeight = "1.4",
                            LetterSpacing = ".01071em"
                        },
                        H1 = new H1Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "6rem",
                            FontWeight = "300",
                            LineHeight = "1.167",
                            LetterSpacing = "-.01562em"
                        },
                        H2 = new H2Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "3.75rem",
                            FontWeight = "300",
                            LineHeight = "1.2",
                            LetterSpacing = "-.00833em"
                        },
                        H3 = new H3Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "3rem",
                            FontWeight = "400",
                            LineHeight = "1.167",
                            LetterSpacing = "0"
                        },
                        H4 = new H4Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "2.3rem",
                            FontWeight = "600",
                            LineHeight = "1.235",
                            LetterSpacing = ".00735em"
                        },
                        H5 = new H5Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "1.5rem",
                            FontWeight = "400",
                            LineHeight = "1.334",
                            LetterSpacing = "0"
                        },
                        H6 = new H6Typography
                        {
                            FontFamily = new[] { "Roboto", "Tahoma", "Verdana", "Arial", "sans-serif" },
                            FontSize = "1.20rem",
                            FontWeight = "400",
                            LineHeight = "1",
                            LetterSpacing = ".0070em"
                        },
                        Button = new ButtonTypography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = ".875rem",
                            FontWeight = "500",
                            LineHeight = "1.75",
                            LetterSpacing = ".02857em"
                        },
                        Body1 = new Body1Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "1rem",
                            FontWeight = "400",
                            LineHeight = "1.1",
                            LetterSpacing = ".0070em"
                        },
                        Body2 = new Body2Typography
                        {
                            FontFamily = new[] { "Roboto", "Tahoma", "Verdana", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = "0.90rem",
                            FontWeight = "400",
                            LineHeight = "1.05",
                            LetterSpacing = ".0070em"
                        },
                        Caption = new CaptionTypography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = ".75rem",
                            FontWeight = "400",
                            LineHeight = "1.66",
                            LetterSpacing = ".03333em"
                        },
                        Subtitle1 = new Subtitle1Typography
                        {
                            FontFamily = new[] { "Roboto", "Tahoma", "Verdana", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = ".875rem",
                            FontWeight = "500",
                            LineHeight = "1",
                            LetterSpacing = ".00714em"
                        },
                        Subtitle2 = new Subtitle2Typography
                        {
                            FontFamily = new[] { "Roboto", "Montserrat", "Helvetica", "Arial", "sans-serif" },
                            FontSize = ".875rem",
                            FontWeight = "500",
                            LineHeight = "1.57",
                            LetterSpacing = ".00714em"
                        },
                    }
                };
            }
        }
    }

    public string DarkLightModeButtonIcon => _isDarkMode switch
    {
        true => Icons.Material.Rounded.AutoMode,
        false => Icons.Material.Outlined.DarkMode,
    };
}
