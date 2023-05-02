using System.Collections;

namespace LendingPaolasBooks.Shared
{
    abstract class EntityBase
    {
        public int id;
        public abstract void UpdateData(EntityBase entity);
        public abstract ArrayList Errors();
    }
}
