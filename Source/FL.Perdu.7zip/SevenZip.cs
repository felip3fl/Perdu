using System.Text;

namespace FL.Perdu._7zip
{
    public class SevenZip
    {
        readonly string SevenZipAddress = @"C:\Program Files\7-Zip\7z.exe";

        public SevenZip()
        {
            checkInstalation();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> compact(string origin, string destination, string fileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = SevenZipAddress;
            startInfo.Arguments = $"a -t7z \"{destination}{fileName}\" \"{origin}\"* -mx=9";
            process.StartInfo = startInfo;
            process.Start();

            return true;
        }

        private bool checkInstalation()
        {
            return true;
        }
    }
}
