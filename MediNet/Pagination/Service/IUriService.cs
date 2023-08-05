using MediNet.Pagination.Filter;

namespace MediNet.Pagination.Service
{
    public interface IUriService
    {
        public Uri GetPageUri(PaginationFilter filter, string route);
    }
}
