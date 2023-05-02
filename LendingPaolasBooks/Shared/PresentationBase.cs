using System.Collections;

namespace LendingPaolasBooks.Shared
{
    abstract class PresentationBase
    {
        protected RepositoryBase repository = null;
        protected EntityBase entity = null;

        public string entityName;
        protected abstract void ReadRecords();
        protected abstract EntityBase GetRecordInfo();

        protected int PresentationGetId()
        {
            int id = 0;
            try
            {
                ColorfulMessage("\nEnter the ID: \n\n-> ", ConsoleColor.Cyan);
                id = Convert.ToInt32(Console.ReadLine());
            }
            catch (FormatException)
            {
                ColorfulMessage("\nThis is not a validy ID!", ConsoleColor.Red);
                SetFooter();
                PresentationGetId();
                return 0;
            }
            return id;
        }

        // CRUD ---------------------------------------------------------------

        public virtual void Create()
        {
            Console.Clear();

            SetHeader($"create new {entityName}");

            EntityBase entity = GetRecordInfo();

            ArrayList errorsList = entity.Errors();

            if(errorsList.Count > 0)
            {
                foreach (string error in errorsList)
                {
                    ColorfulMessage(error, ConsoleColor.Red);
                    SetFooter();
                }

                Create();
                return;
            }

            ColorfulMessage($"\n{entityName} suscessfully created!", ConsoleColor.Green);
            repository.RepositoryCreate(entity);

            SetFooter();
        }

        public virtual void Read()
        {
            Console.Clear();

            if (repository.HasRecords())
                return;

            SetHeader($"view {entityName}'s table");

            ReadRecords();

            SetFooter();
        }

        public virtual void Update()
        {
            Console.Clear();

            SetHeader($"update a {entityName}");

            if (repository.HasRecords())
                return;

            ReadRecords();

            int id = PresentationGetId();
            repository.isValidId(id);

            EntityBase newRecord = GetRecordInfo();
            ColorfulMessage($"\n{entityName} suscessfully updated!", ConsoleColor.Green);
            repository.RepositoryUpdate(id, newRecord);
            SetFooter();
        }

        public virtual void Delete()
        {
            Console.Clear();

            SetHeader($"Delete a {entityName}");

            if (repository.HasRecords())
                return;

            ReadRecords();

            int id = PresentationGetId();
            repository.isValidId(id);

            ColorfulMessage($"\n{entityName} suscessfully deleted!", ConsoleColor.Green);
            repository.RepositoryDelete(id);
            SetFooter();
        }

        // Presentation facitilities ------------------------------------------

        public static void ColorfulMessage(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(message);
            Console.ResetColor();
        }

        public static void SetHeader(string header)
        {
            Console.Clear();

            ColorfulMessage(
              $"\n\n{header.ToUpper()}"
            + "\n------------------------------\n"
            , ConsoleColor.Cyan);
        }

        public static void SetFooter()
        {
            ColorfulMessage("\n\n<-'", ConsoleColor.Cyan);
            Console.ReadLine();
        }

        public static int SetMenu(string entity)
        {
            Console.Clear();

            ColorfulMessage(
              $"\n{entity.ToUpper()}"
            + $"\n-------------------"
            + $"\n[1] Create {entity}."
            + $"\n[2] View {entity}'s table."
            + $"\n[3] Edit a {entity}."
            + $"\n[4] Delete a {entity}." 
            + $"\n[5] Exit."
            + "\n\n→ "
            , ConsoleColor.DarkYellow);

            int selectedOption = Convert.ToInt32(Console.ReadLine());

            Console.Clear();

            return selectedOption;
        }

        public static void SetTable(string[] columnNames, int[] columnWidths, List<object> data)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            // Print - separator
            const int pipeCount = 2;
            const char SeparatorChar = '-';
            int totalWidth = columnWidths.Sum() + columnNames.Length * pipeCount - 1;
            string separator = new string(SeparatorChar, totalWidth);

            Console.WriteLine($"\n {separator}");

            // Print header
            string header = "";
            for (int i = 0; i < columnNames.Length; i++)
            {
                header += String.Format("| {0,-" + columnWidths[i] + "}", columnNames[i].ToUpper());
            }
            Console.WriteLine($"{header}|\n {separator}");

            Console.ResetColor();

            // Print the each row from 'data'
            foreach (object[] row in data)
            {
                string rowString = "";
                for (int i = 0; i < row.Length; i++)
                {
                    rowString += String.Format("| {0,-" + columnWidths[i] + "}", row[i]);
                }
                Console.WriteLine(rowString + "|");
            }
            Console.WriteLine($" {separator}");
        }

        public static string SetStringField(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(
                $"\n{message}"
                + "\n→ ");
            Console.ResetColor();

            string reply = Console.ReadLine();

            return reply;
        }

        public static double SetDoubleField(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(
                $"\n{message}"
                + "\n→ ");
            Console.ResetColor();

            double reply = Convert.ToInt64(Console.ReadLine());

            return reply;
        }
    }
}
