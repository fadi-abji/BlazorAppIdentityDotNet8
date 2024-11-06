using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace BlazorWebApp.Identity
{
    public partial class SetUserInfo : ComponentBase
    {
        /// <summary>
        /// The content to which the authentication state should be provided.
        /// </summary>
        [Parameter]
        public RenderFragment? ChildContent { get; set; }

        [Parameter]
        public bool RenderIfSet { get; set; } = true;

        [Inject]
        internal PersistentAuthenticationStateProvider AuthorizeState { get; set; }

        [CascadingParameter]
        protected Task<AuthenticationState> AuthenticationState { get; set; }

        protected override async Task OnInitializedAsync()
        {
            if (((await AuthenticationState).User.Identity.IsAuthenticated))
            {
                try
                {
                    AuthorizeState.AuthenticationStateChanged += async (state) =>
                    {
                        await InvokeAsync(StateHasChanged);
                    };

                    AuthenticationState = AuthorizeState.GetAuthenticationStateAsync();
                }
                catch (Exception ex)
                {

                }
                finally
                {

                }
            }
        }
    }
}


//public partial class SetUserInfo : ComponentBase
//{
//    /// <summary>
//    /// The content to which the authentication state should be provided.
//    /// </summary>
//    [Parameter]
//    public RenderFragment? ChildContent { get; set; }

//    [Parameter]
//    public bool RenderIfSet { get; set; } = true;

//    [Inject]
//    public ISessionData SessionData { get; set; }

//    [Inject]
//    public ILogger<SetUserInfo> Logger { get; set; }

//    [Inject]
//    public IAuthorizeApi AuthorizeApi { get; set; }

//    [CascadingParameter]
//    protected Task<AuthenticationState> AuthenticationState { get; set; }

//    protected override async Task OnInitializedAsync()
//    {
//        if ((!SessionData.HasUserData) && ((await AuthenticationState).User.Identity.IsAuthenticated))
//        {
//            Logger.LogDebug("In SetUserInfo - OnInitializedAzync - Set SessionData");
//            try
//            {
//                WxrResponse<UserInfo> userInfo = await AuthorizeApi.GetUserInfo();
//                if (userInfo.Success)
//                {
//                    SessionData.UserData = userInfo.Value;
//                }
//                else
//                {
//                    Logger.LogError($"Failed setting Userdata, {userInfo.Message}");
//                }

//            }
//            catch (Exception ex)
//            {
//                Logger.LogError($"Failed to set SessionData.UserData: {ex.Message}");
//            }
//            finally
//            {
//                if (SessionData.HasUserData)
//                {
//                    Logger.LogDebug($"GetUserInfo called in SetUserInfo with ok status");
//                }
//                else
//                {
//                    Logger.LogError($"GetUserInfo called in SetUserInfo with error status");
//                }
//            }
//        }
//    }