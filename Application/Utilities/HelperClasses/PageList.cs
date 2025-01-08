using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTours.Application.Utilities.HelperClasses
{
    public class PageList<T>
    {
        public PageList(IQueryable<T> query, int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;

            TotalItemsCount = query.Count();
            TotalPagesCount = (int)Math.Ceiling(TotalItemsCount / (double)pageSize);

            Items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            HasNextPage = pageNumber < TotalPagesCount;
            HasPreviousPage = pageNumber > 1;
        }

        public IQueryable<T> Items { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalItemsCount { get; set; }
        public int TotalPagesCount { get; set; }
        public bool HasNextPage { get; set; }
        public bool HasPreviousPage { get; set; }

    }
}
