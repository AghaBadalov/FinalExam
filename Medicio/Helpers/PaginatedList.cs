namespace Medicio.Helpers
{
    public class PaginatedList<T> :List<T>
    {
        public PaginatedList(List<T> values,int count,int pagesize,int page)
        {
            ActivePage = page;
            this.AddRange(values);
            TotalPageCount=(int)Math.Ceiling((double)count/pagesize);
        }
        public int TotalPageCount { get; set; }
        public int ActivePage { get; set; }
        public bool HasPrevious { get => ActivePage > 1; }
        public bool HasNext { get => ActivePage < TotalPageCount; }


        public static PaginatedList<T> Create(IQueryable<T> query,int pagesize,int page)
        {
            return new PaginatedList<T>(query.Skip((page - 1) * (pagesize)).Take(pagesize).ToList(), query.Count(), pagesize, page);
        }
    }
}
