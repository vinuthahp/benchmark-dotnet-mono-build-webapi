using System.Linq;
using System.Collections.Generic;

namespace ApiPeople.Utils
{
	public class WrapperDTO<TEntry>
	{
		public int TotalCount { get; private set; }
		public int? Limit { get; private set; }
		public int? Offset { get; private set; }
		public IEnumerable<TEntry> Entries { get; private set; }

		public WrapperDTO(IEnumerable<TEntry> entries)
			: this(
				entries,
				entries != null ? entries.Count() : 0) { }

		public WrapperDTO(IEnumerable<TEntry> entries, int totalCount)
			: this(
				entries,
				totalCount,
				null,
				null) { }

		public WrapperDTO(IEnumerable<TEntry> entries, int totalCount, int? limit, int? offset)
		{
			this.Entries = entries;
			this.TotalCount = totalCount;
			this.Limit = limit;
			this.Offset = offset;

		}
	}
}
