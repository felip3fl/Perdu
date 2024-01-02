using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static void Main(string[] args)
        {
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

        private static void ShowOption()
        {
            
        }
    }
}
