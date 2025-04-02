using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoCot_HC_FE.Handler
{
    public class PaginationHandler<T>
    {
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
        public List<T> Items { get; set; }

        public PaginationHandler(List<T> items, int totalRecord, int pageNumber, int pageSize)
        {
            Items = items;
            TotalRecords = totalRecord;
            PageSize = pageSize;
            CurrentPage = pageNumber;
            TotalPages = (int)Math.Ceiling(totalRecord / (double)pageSize);
        }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}