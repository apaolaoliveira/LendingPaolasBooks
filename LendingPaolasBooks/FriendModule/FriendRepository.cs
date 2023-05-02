using LendingPaolasBooks.Shared;
using System.Collections;

namespace LendingPaolasBooks.FriendModule
{
    internal class FriendRepository : RepositoryBase
    {
        public FriendRepository(ArrayList arrayList)
        {
            _records = arrayList;
        }
    }
}
