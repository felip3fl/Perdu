var destination = "%userprofile%\\OneDrive\\Documents\\Backup\\Games\\Metal gear rising\\";
var origin = "%userprofile%\\Documents\\MGR\\";
var fileName = $"metal_gear_rising_backup_{DateTime.Now.ToString("yyyyMMdd")}_{DateTime.Now.ToString("HHmm")}.7z";

string strCmdText;
strCmdText = $"/C .\\7z.exe a -t7z {destination}temp.7z \"{origin}*\" -mx=9";
Console.WriteLine(strCmdText);
Console.WriteLine(fileName);
//System.Diagnostics.Process.Start("CMD.exe", strCmdText);