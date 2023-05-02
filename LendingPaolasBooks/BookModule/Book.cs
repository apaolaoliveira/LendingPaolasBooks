using LendingPaolasBooks.FriendModule;
using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.BookModule
{
    internal class Book : EntityBase
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Summary { get; set; }

        public Book(int bookId, string title, string author, string summary)
        {
            id = bookId;
            Title = title;
            Author = author;
            Summary = summary;
        }

        public override void UpdateData(EntityBase record)
        {
            Book book = (Book)record;

            Title = book.Title;
            Author = book.Author;
            Summary = book.Summary;
        }

        public override ArrayList Errors()
        {
            ArrayList ErrorsList = new ArrayList();

            if (string.IsNullOrEmpty(Title.Trim()))
                ErrorsList.Add("\nTitle is a required field!");

            if (string.IsNullOrEmpty(Author.Trim()))
                ErrorsList.Add("\nAuthor is a required field!");

            return ErrorsList;
        }

    }
}
