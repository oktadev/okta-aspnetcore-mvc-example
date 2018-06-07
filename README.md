# ASP.NET Core 2.0 MVC + Okta

This example shows how to use Okta, OpenID Connect, and ASP.NET Core 2.0 MVC.

You can follow the **[quickstart](https://developer.okta.com/quickstart/#/okta-sign-in-page/dotnet/aspnetcore)** for this project to see how it was created.

**Prerequisites:** [.NET Core 2.0](https://dot.net/core) or higher.

> [Okta](https://developer.okta.com/) has Authentication and User Management APIs that reduce development time with instant-on, scalable user infrastructure. Okta's intuitive API and expert support make it easy for developers to authenticate, manage and secure users and roles in any application.

* [Getting started](#getting-started)
* [Links](#links)
* [Help](#help)
* [License](#license)

## Getting started

To install this example application, clone this repository with Git:

```bash
git clone https://github.com/oktadeveloper/okta-aspnetcore-mvc-example.git
cd okta-aspnetcore-mvc-example
```

Or download a zip archive of the repository from GitHub and extract it on your machine.

### Create an application in Okta

You will need to create an application in Okta to to perform authentication. 

Log in to your Okta Developer account (or [sign up](https://developer.okta.com/signup/) if you don't have an account) and navigate to **Applications** > **Add Application**. Click **Web**, click **Next**, and give the app a name you'll remember.

Change the **Base URI** to:

```
http://localhost:60611/
```

Change the **Login redirect URI** to:

```
http://localhost:60611/authorization-code/callback
```

Click **Done**. On the General Settings screen, click **Edit**.

Add a **Logout redirect URI**:

```
http://localhost:60611/signout-callback-oidc
```

Scroll to the bottom of the Okta application page to find the client ID and client secret. You'll need those values in the next step.

### Project configuration

Update the `appsettings.json` file with these values:

* `Okta:ClientId` - The client ID of the Okta application
* `Okta:ClientSecret` - The client secret of the Okta application
* `Okta:Issuer` - Replace `{yourOktaDomain}` with your Okta domain, found at the top-right of the the Dashboard page

Optionally, if you want to use the Okta SDK (and test `Account/Me`) make sure to update these values as well:

* `Okta:APIToken` - Your API token obtained from the API section of the Developer Console
* `Okta:OrgUrl` - Replace `{yourOktaDomain}` with your Okta domain, found at the top-right of the Dashboard page

**Note:** The value of `{yourOktaDomain}` should be something like `dev-123456.oktapreview.com`. Make sure you don't include `-admin` in the value!

### Start the application

Run the project with Visual Studio, or with this command:

```bash
dotnet run
```

Browse to `http://localhost:60611` to test the application.

## Links

* [ASP.NET Core + Okta authentication quickstart](https://developer.okta.com/quickstart/#/okta-sign-in-page/dotnet/aspnetcore)
* Use the [Okta .NET SDK](https://github.com/okta/okta-sdk-dotnet) if you need to call [Okta APIs](https://developer.okta.com/docs/api/resources/users) for management tasks

## Help

Please post any questions on the [Okta Developer Forums](https://devforum.okta.com/). You can also email developers@okta.com if you would like to create a support ticket.

## License

Apache 2.0, see [LICENSE](LICENSE).
