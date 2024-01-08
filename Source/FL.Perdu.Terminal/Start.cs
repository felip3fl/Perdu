using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static void Main(string[] args)
        {
            TerminalService terminalService = new TerminalService();

            terminalService.ShowPresentation();
            terminalService.DefineConsoleTitle();

            terminalService.loadPrograms();
            terminalService.showOptions();
            var chosenProgram = terminalService.UserChoiceProgram();
            terminalService.executeBackup(chosenProgram);
        }


    }
}
