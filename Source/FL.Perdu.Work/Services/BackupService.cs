using FL.Perdu._7zip;
using FL.Perdu.Work.Interfaces;

namespace FL.Perdu.Work.Services
{
    public class BackupService : IBackupService
    {
        SevenZip sevenZip = new SevenZip();

        public async Task Backup()
        {
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
