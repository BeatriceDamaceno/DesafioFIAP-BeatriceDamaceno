using Microsoft.EntityFrameworkCore;

namespace Desafio_FIAP___Beatrice_Damaceno.Pages.Turmas
{
    public class TurmaPaginated<T> : List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalRows { get; private set; }

        public TurmaPaginated(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            TotalRows = count;
            this.AddRange(items);
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public static async Task<TurmaPaginated<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
            return new TurmaPaginated<T>(items, count, pageIndex, pageSize);
        }
    }
}
