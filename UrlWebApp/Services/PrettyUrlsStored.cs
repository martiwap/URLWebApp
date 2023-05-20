using UrlWebApp.Models;

namespace UrlWebApp.Services
{
    public class PrettyUrlsStored
    {
        // this would ideally come from a table or db where are stored
        public ListURLViewModel PrettyUrls { get; set; }

        public IDataService DataService { get; set; }

        public PrettyUrlsStored(IDataService dataService)
        {
            DataService = dataService;
            this.PrettyUrls = this.DataService.GetDataSaved();
        }


        public List<string> GetAliasStored()
        {
            if (this.PrettyUrls is null)
                this.PrettyUrls = new ListURLViewModel();
            if (this.PrettyUrls.ListOfModels is null)
                this.PrettyUrls.ListOfModels = new List<URLViewModel>();

            return this.PrettyUrls.ListOfModels.Select(x => x.Alias).ToList();
        }

        // and this would add the new item to the table
        public URLViewModel AddNewPrettyURL(string longUrl, string alias)
        {
            var newPretty = new URLViewModel
            {
                GuidId = Guid.NewGuid(),
                LogUrl = longUrl,
                Alias = alias,
                PrettyUrl = "http://localhost:7136/" + alias,
            };

            this.PrettyUrls.ListOfModels.Add(newPretty);

            // overwrite sile
            this.DataService.SaveDataToJson(this.PrettyUrls);

            return newPretty;
        }

        public string GetLongUrl(string alias)
        {
            return this.PrettyUrls.ListOfModels
                .Where(x => x.Alias == alias)
                .Select(x => x.LogUrl)
                .FirstOrDefault();
        }
    }
}
