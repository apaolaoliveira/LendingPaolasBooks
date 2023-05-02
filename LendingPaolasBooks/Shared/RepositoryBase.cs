using System.Collections;

namespace LendingPaolasBooks.Shared
{
    abstract class RepositoryBase
    {
        protected ArrayList _records;

        public ArrayList SelectedRecords()
        {
            return _records;
        }

        public int idCounter = 1;

        public void increaseId()
        {
            idCounter++;
        }

        // CRUD --------------------------------------------------------------------

        public void RepositoryCreate(EntityBase entity)
        {        
            _records.Add(entity);
            entity.id = idCounter;
            increaseId();
        }

        public void RepositoryUpdate(int id, EntityBase entityEdit)
        {
            EntityBase entityUpdate = RepositoryGetId(id);

            if (entityUpdate == null)
            {
                PresentationBase.ColorfulMessage("Id not found.", ConsoleColor.Red);
                PresentationBase.SetFooter();
                return;
            }

            entityUpdate.UpdateData(entityEdit);
        }

        public void RepositoryDelete(int selectedId)
        {
            if (HasRecords())
                return;

            EntityBase entity = RepositoryGetId(selectedId);
            _records.Remove(entity);
        }

        // Repository facilities ---------------------------------------------------

        public virtual EntityBase RepositoryGetId(int selectedId)
        {
            EntityBase entity = null;

            foreach (EntityBase entityAdded in _records)
            {
                if (entityAdded.id == selectedId)
                {
                    entity = entityAdded;
                    break;
                }
            }
            return entity;
        }

        public virtual int isValidId(int selectedId)
        {
            do
            {
                if (selectedId <= 0 || selectedId > idCounter - 1)
                {
                    PresentationBase.ColorfulMessage("\nThis ID doesn't exist. Try again:" + "\n→ ", ConsoleColor.Red);
                    selectedId = Convert.ToInt32(Console.ReadLine());
                }

                else { break; }

            } while (true);

            return selectedId;
        }

        public bool HasRecords()
        {
            if (_records.Count == 0) 
            {
                PresentationBase.ColorfulMessage("No records found.", ConsoleColor.Red);
                PresentationBase.SetFooter();
                return true; 
            }
            else { return false; }
        }
    }
}
