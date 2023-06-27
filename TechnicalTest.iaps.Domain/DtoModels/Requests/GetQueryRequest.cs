namespace TechnicalTest.iaps.Domain.DtoModels.Requests
{
    public class GetQueryRequest
    {
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}
