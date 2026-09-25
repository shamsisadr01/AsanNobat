namespace AsanNobat.Web.AcceptanceTests.Pages;

public abstract class BasePage(IPage page)
{
    protected static string BaseUrl =>
        AspireSetup.App
            .GetEndpoint(Services.WebFrontend)
            .ToString()
            .Replace("localhost", "app.dev.localhost")
            .TrimEnd('/');

    public abstract string PagePath { get; }

    protected IPage Page { get; } = page;

    public Task GotoAsync() => Page.GotoAsync(PagePath);
}
