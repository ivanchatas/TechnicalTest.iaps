using Newtonsoft.Json;

namespace TechnicalTest.iaps.Domain.DtoModels.Requests
{
    public class PaperAddRequest
    {
        public string Id { get; set; }
        public string Submitter { get; set; }
        public string Title { get; set; }
        public string Comments { get; set; }

        [JsonProperty("journal-ref")]
        public string JournalRef { get; set; }
        public string Doi { get; set; }
        
        [JsonProperty("report-no")]
        public string ReportNo { get; set; }
        public string License { get; set; }
        public string Abstract { get; set; }
        public string Version { get; set; }
        
        [JsonProperty("update_date")]
        public string UpdateDate { get; set; }

        [JsonProperty("authors_parsed")]
        public List<AuthorAddRequest> Authors { get; } = new();
        public List<CategoryAddRequest> Categories { get; } = new();
    }
}
