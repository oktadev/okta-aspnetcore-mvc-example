# Okta + ASP.NET Core MVC example

This example shows how to use Okta as an identity provider in an ASP.NET Core 2.0 MVC application via OpenID Connect.

To get this project running, follow these instructions:

0. If you haven't already, sign up for an [Okta developer account](https://www.okta.com/developer/signup) and log in.
0. Go to Applications and create a new application. Choose the Web platform.
0. Change the **Base URI** to `http://localhost:60611/` and the **Login redirect URI** to `http://localhost:60611/authorization-code/callback`.
0. After the Okta application is created, edit its settings and change the **Logout redirect URI** to `http://localhost:60611/signout-callback-oidc`.
0. Scroll down and copy the Okta application's Client ID and Client Secret into the `appsettings.json` file's `okta` section.
0. Update the `okta:authority` property in `appsettings.json` to reflect your Okta org URL. For example, if your org URL is `dev-1234.oktapreview.com`, the authority should be `https://dev-1234.oktapreview.com/oauth2/default`.

You're all set! Run the project and try signing in with a user assigned in Okta. Once you log in, click on **My claims** to see the user's claims.

## How it works

The ASP.NET Core authentication system is configured in the `Startup` class to use cookies for the local session, and use Okta as an external identity provider via OpenID Connect. Because it's a server-rendered application, the Authorization Code flow is used.

If you want a detailed, step-by-step guide to setting this up in your own project, check out the [Okta + ASP.NET Core 2.0 quickstart](https://developer.okta.com/quickstart/#/okta-sign-in-page/dotnet/aspnetcore).
