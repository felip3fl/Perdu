using System.Text;

var destination = @"%userprofile%\OneDrive\Documents\Backup\Games\Metal gear rising\";
var origin = @"%userprofile%\Documents\MGR\";
var fileName = $"metal_gear_rising_backup_{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.ToString("HHmm")}.7z";

destination = destination.Replace("%userprofile%", System.Environment.GetEnvironmentVariable("USERPROFILE"));
origin = origin.Replace("%userprofile%", System.Environment.GetEnvironmentVariable("USERPROFILE"));

System.Diagnostics.Process process = new System.Diagnostics.Process();
System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
startInfo.FileName = @"C:\Program Files\7-Zip\7z.exe";
startInfo.Arguments = $"a -t7z \"{destination}{fileName}\" \"{origin}\"* -mx=9";
process.StartInfo = startInfo;
process.Start();