using UrlWebApp.Models;

namespace UrlWebApp.Services
{
    public interface IPrettyUrlsStored
    {
        List<string> GetAliasStored();

        URLViewModel AddNewPrettyURL(string longUrl, string alias);

        string GetLongUrl(string prettyUrl);
    }
}