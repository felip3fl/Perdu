using FL.Perdu.Work.Services;

namespace FL.Perdu.Terminal
{
    public class Start
    {
        public static async Task Main(string[] args)
        {
            TerminalService terminalService = new TerminalService();
            terminalService.DefineConsoleTitle();

            terminalService.loadPrograms();
            terminalService.loadProgramOptions();
            terminalService.loadOthersOption();

            while (true)
            {
                Console.Clear();
                terminalService.ShowPresentation();
                terminalService.showOptions("\nPlease select the follow options:\n");
                var chosenProgram = terminalService.UserChoiceProgram();
                await terminalService.executeBackupAsync(chosenProgram);
            }

        }
    }
}
