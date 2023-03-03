using Nettention.Proud;
using ChattingCommon;

namespace ChattingServer
{
    class Program
    {
        
        //---------------------------------------------------------------------
        static void Main(string[] args)
        {
            ServerLauncher launcher = new ServerLauncher();

            try
            {
                launcher.ServerStart();
                Console.Write("Server started.\n");

                while (launcher.runLoop)
                {
                    if (Console.KeyAvailable && Console.ReadKey(true).Key == ConsoleKey.Escape && Console.ReadKey(true).Key == ConsoleKey.Delete)
                    {
                        break;
                    }                    
                }

                Console.Write("Server closed.\n");
                launcher.Dispose();

            } catch (Exception ex)
            {
                Console.Write(ex.ToString());
            }
        }

        //---------------------------------------------------------------------

        


    }
}