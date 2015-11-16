namespace XPlatformMenus.Core.Interfaces
{
    /// <summary>
    /// The LoginService <c>interface</c>.
    /// </summary>
    public interface ILoginService
    {
        /// <summary>
        /// Gets a value indicating whether the user is authenticated.
        /// </summary>
        bool IsAuthenticated { get; }

        /// <summary>
        /// Attempts to log the user in using stored credentials if present
        /// </summary>
        /// <returns> <c>true</c> if the login is successful, <c>false</c> otherwise </returns>
        bool Login();

        /// <summary>The login method to retrieve OAuth2 access tokens from an API. </summary>
        /// <param name="userName">The user Name (email address) </param>
        /// <param name="password">The users <c>password</c>. </param>
        /// <param name="scope">The required scopes. </param>
        /// <returns><c>true</c> if the login is successful, <c>false</c> otherwise </returns>
        bool Login(string userName, string password, string scope);

        /// <summary>
        /// The login method called with user supplied credentials
        /// </summary>
        /// <param name="userName">Name of the user.</param>
        /// <param name="password">The users password.</param>
        /// <returns><c>true</c> if the login is successful, <c>false</c> otherwise </returns>
        bool Login(string userName, string password);
    }
}