using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static void Main(string[] args)
        {
            ShowApresentation();
            DefineConsoleTitle();
            Console.WriteLine("FLex Perdu v1.0");
            ShowOption();

            LocalFileService localFileService = new();
            localFileService.LoadProgramDetail();

            Console.WriteLine("Please select the follow options: ");
            foreach (var item in localFileService.programDetails)
            {
                Console.WriteLine($"[{item.Order.ToString("00")}] {item.Name}");
            }

            Console.Write("\nYour choice: ");

            var userOption = Convert.ToInt32(Console.ReadLine());

            BackupService backupService = new();
            var isSuccess = backupService.Backup(localFileService.programDetails[userOption-1]);
        }

        private static void ShowApresentation()
        {
            Console.WriteLine(@"  ____    ____   __      __      ____     ____      ____   __          ");
            Console.WriteLine(@" / ___\  / ___\ /\ \    /\_\    / __ \  /\___ \    / ___\ /\ \         ");
            Console.WriteLine(@"/\ \__/ /\ \__/ \ \ \   \/\ \  /\ \_\ \ \/___\ \  /\ \__/ \ \ \        ");
            Console.WriteLine(@"\ \  __\\ \  _\  \ \ \   \ \ \ \ \  __/   /\_ \ \ \ \  __\ \ \ \       ");
            Console.WriteLine(@" \ \ \_/ \ \ \/   \ \ \   \ \ \ \ \ \/    \/_\ \ \ \ \ \_/  \ \ \      ");
            Console.WriteLine(@"  \ \ \   \ \ \___ \ \ \___\ \ \ \ \ \       _\_\ \ \ \ \    \ \ \___  ");
            Console.WriteLine(@"   \ \_\   \ \____\ \ \____\\ \_\ \ \_\     /\_____\ \ \_\    \ \____\ ");
            Console.WriteLine(@"    \/_/    \/____/  \/____/ \/_/  \/_/     \/_____/  \/_/     \/____/ ");
        }
            
        private static void DefineConsoleTitle()
        {
            Console.Title = "FL PERDU v1.0";
        }
    }
}
