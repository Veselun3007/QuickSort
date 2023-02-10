using Common.ConsoleIO;
namespace QuickSort.Commands
{
    public abstract class CommandManager
    {
        public CommandManager()
        {
            IniCommandInfoArray();
        }
        protected abstract void IniCommandInfoArray();
        protected CommandInfo[] commandInfoArray;
        protected static void ShowCommandsMenu(CommandInfo[] commandInfoArray, string prompt)
        {
            Console.WriteLine(prompt);
            for (int i = 0; i < commandInfoArray.Length; i++)
            {
                Console.WriteLine("\t{0,2} - {1}", i, commandInfoArray[i].name);
            }
        }
        protected static Command EnterCommand(CommandInfo[] 
            commandInfoArray, string prompt)
        {
            Console.WriteLine();
            int number = Entering.EnterInt32(prompt, 0, commandInfoArray.Length - 1);
            return commandInfoArray[number].command;
        }
        public void Run()
        {
            while (true)
            {
                PrepareScreen();
                ShowCommandsMenu(commandInfoArray,"\n\tList of commands: \n");
                Command command = EnterCommand(commandInfoArray, "\tSelect algorithm`s number: ");
                if (command == null)
                {
                    return;
                }
                command();
            }
        }
        protected abstract void PrepareScreen();
    }
}
