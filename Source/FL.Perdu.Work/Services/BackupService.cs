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
        }

        public async Task<bool> CheckBackup(ProgramDetail programDetail)
        {
            //return await System.IO.File.Exists(programDetail.BackupAddress) && System.IO.File.GetFileSize(programDetail.BackupAddress) > 0;
            return true;
        }


    }
}
