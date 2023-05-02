using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.FriendModule
{
    internal class FriendPresentation : PresentationBase
    {
        public FriendPresentation(FriendRepository friendRepository) 
        {
            repository = friendRepository;
            entityName = "Friend";
        }

        protected override EntityBase GetRecordInfo()
        {
            string name = SetStringField("Name:", ConsoleColor.Cyan);

            string phone = SetStringField("Phone:", ConsoleColor.Cyan);

            string address = SetStringField("Address:", ConsoleColor.Cyan);

            Friend newfriend = new Friend(repository.idCounter, name, address, phone);

            return newfriend;
        }

        protected override void ReadRecords()
        {
            string[] columnNames = { "id", "name", "phone", "address" };
            int[] columnWidths = { 4, 15, 15, 30 };

            List<object> data = new List<object>();

            ArrayList records = repository.SelectedRecords();

            foreach (Friend friend in records)
            {
                data.Add(new object[] { friend.id, friend.Name, friend.Phone, friend.Address });
            }

            SetTable(columnNames, columnWidths, data);
        }
    }
}
