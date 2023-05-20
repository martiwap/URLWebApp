using UrlWebApp.Models;

namespace UrlWebApp.Services
{
    public class ShortenService
    {
 
        public PrettyUrlsStored PrettyUrlsStored { get; set; }

        public ShortenService()
        {
            this.PrettyUrlsStored = new PrettyUrlsStored(new DataService());
        }


        public bool IsAliasValid(string alias)
        {
            if (string.IsNullOrEmpty(alias))
                return false;

            if (alias.Length < 2) // at least 3 digits 
                return false;

            if (IsAlreadyUsed(alias))
                return false;

            return true;
        }

        private bool IsAlreadyUsed(string alias)
        {
            var aliasStored = this.PrettyUrlsStored.GetAliasStored();

            foreach (var aliasUsed in aliasStored)
            {
                if (aliasUsed == alias)
                    return true;
            }

            return false;
        }

        public URLViewModel CreateNewPrettyURL(string longUrl, string alias)
        {
            if (string.IsNullOrEmpty(longUrl))
                throw new Exception("Long URL must be provided");

            if (!IsAliasValid(alias))
                throw new Exception("Alias is already in use, use a different one");

            var prettyThing = this.PrettyUrlsStored.AddNewPrettyURL(longUrl, alias);

            return prettyThing;
        }
    }
}
