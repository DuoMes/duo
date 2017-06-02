using System.Collections.Generic;

namespace Duo.Domain.ViewModels
{
    public class PagedResultsViewModel<TResult>
	{
		public IEnumerable<TResult> Results { get; set; }

		public int TotalResults { get; set; }

		public int PageSize { get; set; }

		public int PageIndex { get; set; }

		public int TotalPages { get; set; }
	}
}