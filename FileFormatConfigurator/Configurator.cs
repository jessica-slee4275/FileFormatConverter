using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileFormatConfigurator
{
    public class Configurator
    {
        public static StringBuilder log = new StringBuilder();

        public static Boolean CommandLine = true;
        public event EventHandler<MessageEventArgs> StatusMessage;
        protected void OnStatusMessage(string statusMessage)
        {
            string msg = "";
            if (CommandLine)
            {
                msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {statusMessage} ";
                Console.WriteLine(msg);
                log.AppendLine(msg);
                Console.ResetColor();
            }
            else
            {
                if (StatusMessage != null)
                {
                    StatusMessage(this, new MessageEventArgs(statusMessage));
                }
            }
        }
        public event EventHandler<MessageEventArgs> ErrorMessage;
        public void LogExceptions(List<Exception> exceptions)
        {
            foreach (var exception in exceptions)
            {
                OnErrorMessage(exception.Message);
            }
        }
        protected void OnErrorMessage(string errorMessage)
        {
            string msg = "";
            if (CommandLine)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                msg = $"{DateTime.Now.ToString(Config.DateTimeFormat)} {errorMessage} ";
                Console.WriteLine(msg);
                log.AppendLine(msg);
                Console.ResetColor();
            }
            else if (ErrorMessage != null)
            {
                ErrorMessage(this, new MessageEventArgs(errorMessage));
            }
        }
    }
    public class MessageEventArgs : EventArgs
    {
        public MessageEventArgs(string message)
        {
            Message = message;
        }

        public string Message { get; private set; }
    }
}
