using FL.Perdu.Model;
using FL.Perdu.SevenZip;
using FL.Perdu.Work.Interfaces;

namespace FL.Perdu.Work.Services
{
    public class BackupService : IBackupService
    {
        public async Task Backup(ProgramDetail programDetail)
        {
            SevenZipPrompt sevenZip = new SevenZipPrompt();

            var destination = programDetail.BackupAddress;
            var origin = programDetail.Address;
            var fileName = $"{programDetail.Name.Replace(" ","_")}_{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.ToString("HHmm")}.7z";
            var userAddress = System.Environment.GetEnvironmentVariable("USERPROFILE");

            destination = destination.Replace("%userprofile%", userAddress);
            origin = origin.Replace("%userprofile%", userAddress);

            sevenZip.compact( origin, destination, fileName);

            CheckBackup(destination + fileName);
        }

        public async Task<bool> CheckBackup(string fileAddress)
        {
            FileInfo info = new FileInfo(fileAddress);
            long tamanho = info.Length;

            if(tamanho > 1)
                return true;

            return false;
        }


    }
}
