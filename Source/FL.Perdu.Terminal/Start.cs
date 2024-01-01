using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("FLex Perdu v1.0");
            ShowOption();

            //BackupService backupService = new();
            //var isSuccess = backupService.Backup();

            LocalFileService localFileService = new();
            localFileService.LoadProgramDetail();

            foreach (var item in localFileService.programDetails)
            {
                Console.WriteLine($"[{item.Order.ToString("00")}] {item.Name}");
            }

            Console.ReadKey();
        }

        private static void ShowOption()
        {
            Console.WriteLine("Please select the follow options: ");
        }
    }
}
