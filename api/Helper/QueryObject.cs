﻿namespace api.Helper
{
    public class QueryObject
    {
        public string? Symbol { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null;
        public bool isDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int pageSize { get; set; } = 10;
    }
}
