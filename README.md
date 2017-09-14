# Okta + ASP.NET Core MVC example

This example shows how to use Okta as an identity provider in an ASP.NET Core 2.0 MVC application via OpenID Connect.

To get this example project running, follow these instructions:

0. Clone or download this project to your machine.
0. Find out what address and port the project will run on. In Visual Studio or Visual Studio Code, press F5 to run the project. You can also start it from the command line by running `dotnet run` inside the project folder (`OktaAspNetCoreMvc`). Pay attention to the address that ASP.NET Core starts listening on. It will look like `http://localhost:60611`, but may be randomized on your machine.
0. If you haven't already, sign up for an [Okta developer organization](https://www.okta.com/developer/signup).

After you activate and log into your organization, complete these steps in the Okta developer console:

3. Go to Applications and create a new application. Choose the Web platform.
0. Change the **Base URI** to `http://localhost:60611/` and the **Login redirect URI** to `http://localhost:60611/authorization-code/callback`. (If your project is running on a different port, use that instead.)
0. After the Okta application is created, edit its settings and change the **Logout redirect URI** to `http://localhost:60611/signout-callback-oidc`.
0. Scroll down and copy the Okta application's Client ID and Client Secret into the `appsettings.json` file's `okta` section.
0. Update the `okta:authority` property in `appsettings.json` to reflect your Okta org URL. For example, if your org URL is `dev-1234.oktapreview.com`, the authority should be `https://dev-1234.oktapreview.com/oauth2/default`.

You're all set! Run the project and try signing in with a user assigned in Okta. Once you log in, click on **My claims** to see the user's claims.

If you see an error instead, don't worry! Jump down to the Troubleshooting section below.

## How it works

In this project, the ASP.NET Core authentication system is configured in the `Startup` class to use cookies for the local session, and use Okta as an external identity provider via OpenID Connect. Because it's a server-rendered application, the authorization code flow is used.

If you want a detailed, step-by-step guide to setting this up in your own project, check out the [Okta + ASP.NET Core 2.0 quickstart](https://developer.okta.com/quickstart/#/okta-sign-in-page/dotnet/aspnetcore).

## Troubleshooting

* **"Unable to obtain configuration from..."** errors (IDX10803) are caused by an incorrect `okta:authority` setting in `appsettings.json`. Either the authorization server (issuer) URL in that setting is incorrect, or you don't have an authorization server called `default` in your Okta organization. You can check this by going to **API - Authorization Servers** in the Okta developer console. If you don't see an authorization server called `default` listed there, create a new authorization server and use that issuer URL in `okta:authority` instead.

If you're still stuck, we're happy to help! You can connect with us via:

* The Okta [Developer Forum](https://devforum.okta.com/)
* Email: developers@okta.com
