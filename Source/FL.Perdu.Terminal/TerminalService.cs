using FL.Perdu.Model;
using FL.Perdu.Work.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FL.Perdu.Terminal
{
    public class TerminalService
    {
        public List<ProgramDetail> programDetails;

        public ProgramDetail UserChoiceProgram()
        {
            Console.Write("\nYour choice: ");

            var userOption = Convert.ToInt32(Console.ReadLine());
            var chosenProgram = programDetails[userOption - 1];

            return chosenProgram;
        }

        public void executeBackup(ProgramDetail programDetail)
        {
            BackupService backupService = new();
            var isSuccess = backupService.Backup(programDetail);
        }

        public void showOptions()
        {
            Console.WriteLine("\nPlease select the follow options: ");
            foreach (var item in programDetails)
            {
                Console.WriteLine($"[{item.Order.ToString("00")}] {item.Name}");
            }
        }

        public void loadPrograms()
        {
            LocalFileService localFileService = new();
            programDetails = localFileService.LoadProgramDetail();
        }

        public void ShowPresentation()
        {
            Console.WriteLine("  ____    ____   __      __      ____     ____      ____   __  ");
            Console.WriteLine(" / ___\\  / ___\\ /\\ \\    /\\_\\    / __ \\  /\\___ \\    / ___\\ /\\ \\  ");
            Console.WriteLine("/\\ \\__/ /\\ \\__/ \\ \\ \\   \\/\\ \\  /\\ \\_\\ \\ \\/___\\ \\  /\\ \\__/ \\ \\ \\   FLex");
            Console.WriteLine("\\ \\  __\\\\ \\  _\\  \\ \\ \\   \\ \\ \\ \\ \\  __/   /\\_ \\ \\ \\ \\  __\\ \\ \\ \\   PERDU");
            Console.WriteLine(" \\ \\ \\_/ \\ \\ \\/   \\ \\ \\   \\ \\ \\ \\ \\ \\/    \\/_\\ \\ \\ \\ \\ \\_/  \\ \\ \\   v1.0");
            Console.WriteLine("  \\ \\ \\   \\ \\ \\___ \\ \\ \\___\\ \\ \\ \\ \\ \\       _\\_\\ \\ \\ \\ \\    \\ \\ \\___  ");
            Console.WriteLine("   \\ \\_\\   \\ \\____\\ \\ \\____\\\\ \\_\\ \\ \\_\\     /\\_____\\ \\ \\_\\    \\ \\____\\ ");
            Console.WriteLine("    \\/_/    \\/____/  \\/____/ \\/_/  \\/_/     \\/_____/  \\/_/     \\/____/ ");
        }

        public void DefineConsoleTitle()
        {
            Console.Title = "FL PERDU v1.0";
        }
    }
}
