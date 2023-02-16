namespace HPlusSport.API.Models
{
    public class QueryParameters
    {
        const int MaxSize = 100;
        private int _size = 50;

        public int Page { get; set; } = 1;
        public int Size
        {
            get
            {
                return _size;
            }
            set
            {
                // Return the smaller of two 32-bit signed integers.
                _size = Math.Min(MaxSize, value);
            }
        }

        public string SortBy { get; set; } = "Id";

        private string _sortOrder = "asc";

        public string SortOrder 
        {
            get
            {
                return _sortOrder;
            }
            set
            {
                if (value == "asc" || value == "desc")
                {
                    _sortOrder = value;
                }
            }
        }
    }
}
