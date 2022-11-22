namespace SweetIncApi.Params
{
    public class BaseParams
    {
        private readonly int MaxPageSize = 50;
        private int _pageSize = 10;
        public int PageSize 
        {
            get { return _pageSize; } 
            set { _pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int PageNumber { get; set; } = 1;
        public int SortField { get; set; }
        public bool IsAscending { get; set; }
        public string Keyword { get; set; }

    }
}
