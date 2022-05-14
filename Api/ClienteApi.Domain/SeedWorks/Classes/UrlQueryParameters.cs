namespace ClienteApi.Domain.SeedWorks.Classes
{
    public record UrlQueryParameters(
        int Page = 1,
        int Size = 50,
        string Sort = "",
        bool Order = true,
        string Search =  ""
    );
}