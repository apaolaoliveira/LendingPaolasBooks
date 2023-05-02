using LendingPaolasBooks.BookModule;
using LendingPaolasBooks.FriendModule;
using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BookRepository bookRepository = new BookRepository(new ArrayList());
            BookPresentation bookPresentation = new BookPresentation(bookRepository);
            BookPresentation book = bookPresentation;

            FriendRepository friendRepository = new FriendRepository(new ArrayList());
            FriendPresentation friendPresentation = new FriendPresentation(friendRepository);
            FriendPresentation friend = friendPresentation;

            bool proceedMain = true;

            while (proceedMain)
            {
                Console.Clear();

                PresentationBase.ColorfulMessage(
                  $"\nMain Menu"
                + $"\n-------------------"
                + $"\n[1] Friends"
                + $"\n[2] Books"
                + $"\n[3] Exit."
                + "\n\n→ "
                , ConsoleColor.DarkYellow);

                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        bool proceedFriend = true;       

                        while (proceedFriend)
                        {
                            int friendOption = FriendPresentation.SetMenu("friend");

                            switch (friendOption)
                            {
                                case 1: friend.Create(); break;
                                case 2: friend.Read(); break;
                                case 3: friend.Update(); break;
                                case 4: friend.Delete(); break;
                                case 5: proceedFriend = false; break;
                            }
                        }
                        
                        break;

                    case 2:
                        bool proceedBook = true;

                        while (proceedBook)
                        {
                            int bookOption = BookPresentation.SetMenu("book");

                            switch (bookOption)
                            {
                                case 1: book.Create(); break;
                                case 2: book.Read(); break;
                                case 3: book.Update(); break;
                                case 4: book.Delete(); break;
                                case 5: proceedFriend = false; break;
                            }
                        }

                        break;

                    case 3: 
                        proceedMain = false;              
                        
                        break;
                }
            }
            PresentationBase.ColorfulMessage("\n\nHave a great day!", ConsoleColor.DarkCyan);
            PresentationBase.ColorfulMessage("\n\n<-'", ConsoleColor.DarkCyan);

            Console.ReadKey();
        }
    }
}