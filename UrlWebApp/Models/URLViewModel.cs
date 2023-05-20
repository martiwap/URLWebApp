namespace UrlWebApp.Models
{
    public class URLViewModel : IGenericModel
    {
        public Guid GuidId { get; set; }

        public string LogUrl { get; set; }

        public string Alias { get; set; }

        public string PrettyUrl { get; set; }
    }
}
