namespace UrlShortener.Models.Dto;

public class GetGuid
{
    public string? GetGuidd()
    {
        Guid g =Guid.NewGuid();
        string? stringGuid = Convert.ToString(g);
        stringGuid = stringGuid?.Replace("-", "");
        return stringGuid;
    }
}