using FL.Perdu.SevenZip;
using FL.Perdu.Work.Interfaces;

namespace FL.Perdu.Work.Services
{
    public class BackupService : IBackupService
    {
        public async Task Backup()
        {
            SevenZipPrompt sevenZip = new SevenZipPrompt();

            var destination = @"%userprofile%\OneDrive\Documents\Backup\Games\Metal gear rising\";
            var origin = @"%userprofile%\Documents\MGR\";
            var fileName = $"metal_gear_rising_backup_{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.ToString("HHmm")}.7z";
            var userAddress = System.Environment.GetEnvironmentVariable("USERPROFILE");

            destination = destination.Replace("%userprofile%", userAddress);
            origin = origin.Replace("%userprofile%", userAddress);

            sevenZip.compact( origin, destination, fileName);
        }
    }
}
