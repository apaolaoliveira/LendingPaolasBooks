using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.BookModule
{
    internal class BookRepository : RepositoryBase
    {
        public BookRepository(ArrayList arrayList)
        {
            _records = arrayList;
        }
    }
}
