namespace Core.Specifictions
{
    public class MountainsSpecParams
    {
        public int PageIndex {get; set;} = 1;
        public int? VoivodeshipId {get; set;}
        public int? MountainsRangeId {get; set;}
        public string Sort {get; set;}
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }
        private const int MaxPageSize = 50;
        private int _pageSize = 28;

        private string _search;

        public string Search 
        {
            get => _search;
            set => _search = value.ToLower();
        }

    }
}