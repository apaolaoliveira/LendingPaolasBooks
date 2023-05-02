using LendingPaolasBooks.FriendModule;
using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.BookModule
{
    internal class BookPresentation : PresentationBase
    {
        public BookPresentation(BookRepository bookRepository)
        {
            repository = bookRepository;
            entityName = "Book";
        }

        protected override EntityBase GetRecordInfo()
        {
            string title = SetStringField("Title:", ConsoleColor.Cyan);

            string author = SetStringField("Author:", ConsoleColor.Cyan);

            string summary = SetStringField("Summary:", ConsoleColor.Cyan);

            Book newBook = new Book(repository.idCounter, title, author, summary);

            return newBook;
        }

        protected override void ReadRecords()
        {
            string[] columnNames = { "id", "title", "author", "summary" };
            int[] columnWidths = { 4, 15, 15, 30 };

            List<object> data = new List<object>();

            ArrayList records = repository.SelectedRecords();

            foreach (Book book in records)
            {
                data.Add(new object[] { book.id, book.Title, book.Author, book.Summary });
            }

            SetTable(columnNames, columnWidths, data);
        }
    }
}
