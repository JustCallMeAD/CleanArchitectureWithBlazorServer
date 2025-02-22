using Microsoft.AspNetCore.Components;
using Blazor.Server.UI.Models;
using Blazor.Server.UI.Models.Notification;
using Blazor.Server.UI.Services;

namespace Blazor.Server.UI.Components.Shared;

public partial class NavMenu
{
    private IEnumerable<NotificationModel> _activeNotifications;

    [Inject] private INotificationsService NotificationsService { get; set; }

    [EditorRequired] [Parameter] public ThemeManagerModel ThemeManager { get; set; } = default!;
    [EditorRequired] [Parameter] public bool SideMenuDrawerOpen { get; set; }
    [EditorRequired] [Parameter] public EventCallback ToggleSideMenuDrawer { get; set; }
    [EditorRequired] [Parameter] public EventCallback OpenCommandPalette { get; set; }
    [EditorRequired] [Parameter] public UserModel User { get; set; } = default!;

    [EditorRequired] [Parameter] public bool RightToLeft { get; set; }
    [EditorRequired] [Parameter] public EventCallback RightToLeftToggle { get; set; }


    protected override async Task OnInitializedAsync()
    {
        _activeNotifications = await NotificationsService.GetActiveNotifications();
    }
}