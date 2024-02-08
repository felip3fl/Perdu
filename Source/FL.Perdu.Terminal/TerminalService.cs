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
        public List<ProgramDetail> programDetails = new();
        public List<TerminalOptionList> terminalOptionLists = new();

        public ProgramDetail UserChoiceProgram()
        {
            Console.Write("\nYour choice: ");

            var userOption = Convert.ToInt32(Console.ReadLine());

            var option = terminalOptionLists.Where(x => x.id == userOption).FirstOrDefault();

            if (option.terminalOptionType == TerminalOptionType.exit)
            {
                return null;
            }

            var chosenProgram = programDetails.Where(y => y.Name == option.optionName).FirstOrDefault();

            return chosenProgram;
        }

        public async Task executeBackupAsync(ProgramDetail programDetail)
        {
            Console.Clear();
            BackupService backupService = new();
            await backupService.Backup(programDetail);
        }

        private bool checkListSize()
        {
            if (programDetails.Count == 0)
                return false;

            return true;
        }

        public void loadProgramOptions()
        {
            if (!checkListSize())
            {
                Console.WriteLine("\nATENTION: There is no program");
            }
            else
            {
                foreach (var item in programDetails)
                {
                    terminalOptionLists.Add(new TerminalOptionList { 
                        id = terminalOptionLists.Count + 1, 
                        optionName = item.Name, 
                        terminalOptionType = TerminalOptionType.program 
                    });
                }
            }
        }

        public void showOptions(string message = "")
        {
            Console.WriteLine(message);

            foreach (var item in terminalOptionLists)
                Console.WriteLine(
                    $"[{item.id.ToString("00")}] " +
                    $"{item.optionName}");
        }

        public void loadOthersOption()
        {
            Console.WriteLine();

            if (programDetails.Count > 1)
                terminalOptionLists.Add(new TerminalOptionList { 
                    id = terminalOptionLists.Count + 1, 
                    optionName = "All", 
                    terminalOptionType = TerminalOptionType.allProgram 
                });

            terminalOptionLists.Add(new TerminalOptionList
            {
                id = terminalOptionLists.Count + 1,
                optionName = "Exit",
                terminalOptionType = TerminalOptionType.exit
            });
            
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
