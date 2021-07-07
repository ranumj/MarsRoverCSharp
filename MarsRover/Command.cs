using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; } // MOVE and MODE_CHANGE
        public int NewPosition { get; set; } // Any integer
        public string NewMode { get; set; } // NORMAL or LOW_POWER


        public Command() { }

        public Command(string commandType)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else
            {
                CommandType = commandType;
            }
        }

        public Command(string commandType, int value) // ("MOVE", 500)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else
            {
                CommandType = commandType;
                NewPosition = value;
            }
        }

        public Command(string commandType, string mode)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else
            {
                CommandType = commandType;
                NewMode = mode;
            }
        }

    }
}
