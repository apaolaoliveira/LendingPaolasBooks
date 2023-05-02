using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.FriendModule
{
    internal class Friend : EntityBase
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }

        public Friend(int friendId, string name, string address, string phone)
        {
            id = friendId;
            Name = name;
            Address = address;
            Phone = phone;
        }

        public override void UpdateData(EntityBase record)
        {
            Friend friend = (Friend)record;

            Name = friend.Name;
            Address = friend.Address;
            Phone = friend.Phone;
        }

        public override ArrayList Errors()
        {
            ArrayList ErrorsList = new ArrayList();

            if (string.IsNullOrEmpty(Name.Trim()))
                ErrorsList.Add("\n'Name' is a required field!");

            if (string.IsNullOrEmpty(Phone.Trim()))
                ErrorsList.Add("\n'Phone' is a required field!");

            return ErrorsList;
        }
    }
}
