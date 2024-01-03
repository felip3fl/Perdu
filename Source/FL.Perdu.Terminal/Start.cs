using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static void Main(string[] args)
        {
            ShowPresentation();
            DefineConsoleTitle();

            LocalFileService localFileService = new();
            localFileService.LoadProgramDetail();

            Console.WriteLine("\nPlease select the follow options: ");
            foreach (var item in localFileService.programDetails)
            {
                Console.WriteLine($"[{item.Order.ToString("00")}] {item.Name}");
            }

            Console.Write("\nYour choice: ");

            var userOption = Convert.ToInt32(Console.ReadLine());

            BackupService backupService = new();
            var isSuccess = backupService.Backup(localFileService.programDetails[userOption-1]);
        }

        private static void ShowPresentation()
        {
            Console.WriteLine("  ____    ____   __      __      ____     ____      ____   __  ");
            Console.WriteLine(" / ___\\  / ___\\ /\\ \\    /\\_\\    / __ \\  /\\___ \\    / ___\\ /\\ \\  ");
            Console.WriteLine("/\\ \\__/ /\\ \\__/ \\ \\ \\   \\/\\ \\  /\\ \\_\\ \\ \\/___\\ \\  /\\ \\__/ \\ \\ \\   FLex");
            Console.WriteLine("\\ \\  __\\\\ \\  _\\  \\ \\ \\   \\ \\ \\ \\ \\  __/   /\\_ \\ \\ \\ \\  __\\ \\ \\ \\   PERDU");
            Console.WriteLine(" \\ \\ \\_/ \\ \\ \\/   \\ \\ \\   \\ \\ \\ \\ \\ \\/    \\/_\\ \\ \\ \\ \\ \\_/  \\ \\ \\   v1.0");
            Console.WriteLine("  \\ \\ \\   \\ \\ \\___ \\ \\ \\___\\ \\ \\ \\ \\ \\       _\\_\\ \\ \\ \\ \\    \\ \\ \\___  ");
            Console.WriteLine("   \\ \\_\\   \\ \\____\\ \\ \\____\\\\ \\_\\ \\ \\_\\     /\\_____\\ \\ \\_\\    \\ \\____\\ ");
            Console.WriteLine("    \\/_/    \\/____/  \\/____/ \\/_/  \\/_/     \\/_____/  \\/_/     \\/____/ ");
        }

        private static void DefineConsoleTitle()
        {
            Console.Title = "FL PERDU v1.0";
        }
    }
}
