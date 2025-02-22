using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using Blazor.Server.UI.Components.Shared;
using Blazor.Server.UI.Models;
using Toolbelt.Blazor.HotKeys;
using Microsoft.AspNetCore.Components.Authorization;
using CleanArchitecture.Blazor.Infrastructure.Extensions;

namespace Blazor.Server.UI.Shared;

public partial class MainLayout : IDisposable
{
    private readonly Palette _darkPalette = new()
    {
        Black = "#27272f",
        Background = "rgb(21,27,34)",
        BackgroundGrey = "#27272f",
        Surface = "#212B36",
        DrawerBackground = "rgb(21,27,34)",
        DrawerText = "rgba(255,255,255, 0.50)",
        DrawerIcon = "rgba(255,255,255, 0.50)",
        AppbarBackground = "#27272f",
        AppbarText = "rgba(255,255,255, 0.70)",
        TextPrimary = "rgba(255,255,255, 0.70)",
        TextSecondary = "rgba(255,255,255, 0.50)",
        ActionDefault = "#adadb1",
        ActionDisabled = "rgba(255,255,255, 0.26)",
        ActionDisabledBackground = "rgba(255,255,255, 0.12)",
        Divider = "rgba(255,255,255, 0.12)",
        DividerLight = "rgba(255,255,255, 0.06)",
        TableLines = "rgba(255,255,255, 0.12)",
        LinesDefault = "rgba(255,255,255, 0.12)",
        LinesInputs = "rgba(255,255,255, 0.3)",
        TextDisabled = "rgba(255,255,255, 0.2)"
    };

    private readonly Palette _lightPalette = new()
    {
            Primary = "#2d4275",
            Black = "#0A0E19",
            //Tertiary = "#00B5E2",
            Success = "#64A70B",
            Secondary = "#728BC9",
            //Info = "#2879A8"
    };
    private readonly MudTheme _theme = new()
    {
        //Shadows = new() {
        //    Elevation = new string[]
        //    {
        //    "none",
        //    "0 2px 4px -1px rgba(6, 24, 44, 0.2)",
        //    "0px 3px 1px -2px rgba(0,0,0,0.2),0px 2px 2px 0px rgba(0,0,0,0.14),0px 1px 5px 0px rgba(0,0,0,0.12)",
        //    "0 30px 60px rgba(0,0,0,0.12)",
        //    "0 6px 12px -2px rgba(50,50,93,0.25),0 3px 7px -3px rgba(0,0,0,0.3)",
        //    "0 50px 100px -20px rgba(50,50,93,0.25),0 30px 60px -30px rgba(0,0,0,0.3)",
        //    "0px 3px 5px -1px rgba(0,0,0,0.2),0px 6px 10px 0px rgba(0,0,0,0.14),0px 1px 18px 0px rgba(0,0,0,0.12)",
        //    "0px 4px 5px -2px rgba(0,0,0,0.2),0px 7px 10px 1px rgba(0,0,0,0.14),0px 2px 16px 1px rgba(0,0,0,0.12)",
        //    "0px 5px 5px -3px rgba(0,0,0,0.2),0px 8px 10px 1px rgba(0,0,0,0.14),0px 3px 14px 2px rgba(0,0,0,0.12)",
        //    "0px 5px 6px -3px rgba(0,0,0,0.2),0px 9px 12px 1px rgba(0,0,0,0.14),0px 3px 16px 2px rgba(0,0,0,0.12)",
        //    "0px 6px 6px -3px rgba(0,0,0,0.2),0px 10px 14px 1px rgba(0,0,0,0.14),0px 4px 18px 3px rgba(0,0,0,0.12)",
        //    "0px 6px 7px -4px rgba(0,0,0,0.2),0px 11px 15px 1px rgba(0,0,0,0.14),0px 4px 20px 3px rgba(0,0,0,0.12)",
        //    "0px 7px 8px -4px rgba(0,0,0,0.2),0px 12px 17px 2px rgba(0,0,0,0.14),0px 5px 22px 4px rgba(0,0,0,0.12)",
        //    "0px 7px 8px -4px rgba(0,0,0,0.2),0px 13px 19px 2px rgba(0,0,0,0.14),0px 5px 24px 4px rgba(0,0,0,0.12)",
        //    "0px 7px 9px -4px rgba(0,0,0,0.2),0px 14px 21px 2px rgba(0,0,0,0.14),0px 5px 26px 4px rgba(0,0,0,0.12)",
        //    "0px 8px 9px -5px rgba(0,0,0,0.2),0px 15px 22px 2px rgba(0,0,0,0.14),0px 6px 28px 5px rgba(0,0,0,0.12)",
        //    "0px 8px 10px -5px rgba(0,0,0,0.2),0px 16px 24px 2px rgba(0,0,0,0.14),0px 6px 30px 5px rgba(0,0,0,0.12)",
        //    "0px 8px 11px -5px rgba(0,0,0,0.2),0px 17px 26px 2px rgba(0,0,0,0.14),0px 6px 32px 5px rgba(0,0,0,0.12)",
        //    "0px 9px 11px -5px rgba(0,0,0,0.2),0px 18px 28px 2px rgba(0,0,0,0.14),0px 7px 34px 6px rgba(0,0,0,0.12)",
        //    "0px 9px 12px -6px rgba(0,0,0,0.2),0px 19px 29px 2px rgba(0,0,0,0.14),0px 7px 36px 6px rgba(0,0,0,0.12)",
        //    "0px 10px 13px -6px rgba(0,0,0,0.2),0px 20px 31px 3px rgba(0,0,0,0.14),0px 8px 38px 7px rgba(0,0,0,0.12)",
        //    "0px 10px 13px -6px rgba(0,0,0,0.2),0px 21px 33px 3px rgba(0,0,0,0.14),0px 8px 40px 7px rgba(0,0,0,0.12)",
        //    "0px 10px 14px -6px rgba(0,0,0,0.2),0px 22px 35px 3px rgba(0,0,0,0.14),0px 8px 42px 7px rgba(0,0,0,0.12)",
        //    "0 50px 100px -20px rgba(50, 50, 93, 0.25), 0 30px 60px -30px rgba(0, 0, 0, 0.30)",
        //    "2.8px 2.8px 2.2px rgba(0, 0, 0, 0.02),6.7px 6.7px 5.3px rgba(0, 0, 0, 0.028),12.5px 12.5px 10px rgba(0, 0, 0, 0.035),22.3px 22.3px 17.9px rgba(0, 0, 0, 0.042),41.8px 41.8px 33.4px rgba(0, 0, 0, 0.05),100px 100px 80px rgba(0, 0, 0, 0.07)",
        //    "0px 0px 20px 0px rgba(0, 0, 0, 0.05)"
        //    }
        //},
        Palette = new Palette
        {
            Primary = "#2d4275",
        },
        LayoutProperties = new LayoutProperties
        {
            AppbarHeight = "80px",
            DefaultBorderRadius = "6px",
        },
        Typography = new Typography
        {
            Default = new Default
            {
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = "normal",
                FontFamily = new string[] { "Public Sans", "Roboto", "Arial", "sans-serif" }
            },
            H1 = new H1
            {
                FontSize = "4rem",
                FontWeight = 700,
                LineHeight = 1.167,
                LetterSpacing = "-.01562em"
            },
            H2 = new H2
            {
                FontSize = "3.75rem",
                FontWeight = 300,
                LineHeight = 1.2,
                LetterSpacing = "-.00833em"
            },
            H3 = new H3
            {
                FontSize = "3rem",
                FontWeight = 600,
                LineHeight = 1.8,
                LetterSpacing = "0"
            },
            H4 = new H4
            {
                FontSize = "1.8rem",
                FontWeight = 700,
                LineHeight = 1.235,
                LetterSpacing = ".007em"
            },
            H5 = new H5
            {
                FontSize = "1.8rem",
                FontWeight = 700,
                LineHeight = 2,
                LetterSpacing = "0"
            },
            H6 = new H6
            {
                FontSize = "1.125rem",
                FontWeight = 700,
                LineHeight = 2,
                LetterSpacing = ".0075em"
            },
            Button = new Button
            {
                FontSize = ".875rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = ".02857em"
            },
            Subtitle1 = new Subtitle1
            {
                FontSize = "1.1rem",
                FontWeight = 500,
                LineHeight = 1.75,
                LetterSpacing = ".00938em"
            },
            Subtitle2 = new Subtitle2
            {
                FontSize = "1rem",
                FontWeight = 600,
                LineHeight = 1.8,
                LetterSpacing = ".00714em"
            },
            Body1 = new Body1
            {
                FontSize = "1rem",
                FontWeight = 400,
                LineHeight = 1.5,
                LetterSpacing = ".00938em"
            },
            Body2 = new Body2
            {
                FontSize = ".875rem",
                FontWeight = 400,
                LineHeight = 1.43,
                LetterSpacing = ".01071em"
            },
            Caption = new Caption
            {
                FontSize = ".75rem",
                FontWeight = 400,
                LineHeight = 1.66,
                LetterSpacing = ".03333em"
            },
            Overline = new Overline
            {
                FontSize = ".75rem",
                FontWeight = 400,
                LineHeight = 2.66,
                LetterSpacing = ".08333em"
            }
        }
    }; 

    private  UserModel _user = new()
    {
        Avatar = "./sample-data/avatar.png",
        DisplayName = "MudDemo",
        Email = "muddemo@demo.com.au",
        Role = "Admin"
    };

    private bool _commandPaletteOpen;

    private HotKeysContext? _hotKeysContext;
    private bool _sideMenuDrawerOpen = true;
    private bool _rightToLeft = false;
    private ThemeManagerModel _themeManager = new();
 

    private bool _themingDrawerOpen;
    [Inject] private IDialogService _dialogService { get; set; } = default!;
    [Inject] private HotKeys _hotKeys { get; set; } = default!;
    [Inject] private ILocalStorageService _localStorage { get; set; } = default!;
    [CascadingParameter]
    protected Task<AuthenticationState> AuthState { get; set; } = default!;
    public void Dispose()
    {
        _hotKeysContext?.Dispose();
    }
  
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            if (await _localStorage.ContainKeyAsync("themeManager"))
                _themeManager = await _localStorage.GetItemAsync<ThemeManagerModel>("themeManager");
            await ThemeManagerChanged(_themeManager);
            StateHasChanged();
        }
    }
    protected override async Task OnInitializedAsync()
    {
        var state = await AuthState;
        _user = new UserModel()
        {
             Avatar = state.User.GetProfilePictureDataUrl(),
             DisplayName = state.User.GetDisplayName(),
             Email = state.User.GetEmail(),
             Role = state.User.GetRoles().FirstOrDefault()
        };
        _hotKeysContext = _hotKeys.CreateContext()
            .Add(ModKeys.Meta, Keys.K, OpenCommandPalette, "Open command palette.");
    }
    protected void SideMenuDrawerOpenChangedHandler(bool state)
    {
        _sideMenuDrawerOpen = state;
    }
    protected void ThemingDrawerOpenChangedHandler(bool state)
    {
        _themingDrawerOpen = state;
    }
    protected void ToggleSideMenuDrawer()
    {
        _sideMenuDrawerOpen = !_sideMenuDrawerOpen;
    }
    protected void RightToLeftToggleHandler()
    {
        _rightToLeft = !_rightToLeft;
    }

    protected async Task ThemeManagerChanged(ThemeManagerModel themeManager)
    {
        _themeManager = themeManager;

        _theme.Palette = _themeManager.IsDarkMode ? _darkPalette : _lightPalette;
        _theme.Palette.Primary = _themeManager.PrimaryColor;
        _theme.LayoutProperties.DefaultBorderRadius = _themeManager.BorderRadius + "px";
        await UpdateThemeManagerLocalStorage();
    }

    private async Task OpenCommandPalette()
    {
        if (!_commandPaletteOpen)
        {
            var options = new DialogOptions
            {
                NoHeader = true,
                MaxWidth = MaxWidth.Medium,
                FullWidth = true
            };

            var commandPalette = _dialogService.Show<CommandPalette>("", options);
            _commandPaletteOpen = true;

            await commandPalette.Result;
            _commandPaletteOpen = false;
        }
    }

    private async Task UpdateThemeManagerLocalStorage()
    {
        await _localStorage.SetItemAsync("themeManager", _themeManager);
    }
}