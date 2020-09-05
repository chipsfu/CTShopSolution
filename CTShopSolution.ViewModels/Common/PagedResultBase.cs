using System;

namespace CTShopSolution.ViewModels.Common
{
    public class PagedResultBase : PagingRequestBase
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public int TotalRecords { get; set; }

        public int PageCount
        {
            get
            {
                var pageCount = (double)TotalRecords / PageSize;
                return (int)Math.Ceiling(pageCount);
            }
        }
    }
}
