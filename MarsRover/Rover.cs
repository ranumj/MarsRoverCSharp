using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; } // LOW_POWER or NORMAL
        public int Position { get; set; } // An integer
        public int GeneratorWatts { get; set; }

        public Rover(int position) // Rover rover1 = new Rover("NORMAL", 5, 7);
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }

        public Rover(string mode, int position, int generatorWatts)
        {
            Mode = mode;
            Position = position;
            GeneratorWatts = generatorWatts;
        }

        public void ReceiveMessage(Message message)
        {
            if (message.Commands != null)
            {
                foreach (Command command in message.Commands)
                {
                    if (command.CommandType.Equals("MOVE"))
                    {
                        if (Mode != "LOW_POWER")
                        {
                            Position = command.NewPosition;
                        }
                        else
                        {
                            throw new ArgumentException("Rover is in low power mode; cannot move.");
                        }
                    }
                    else if (command.CommandType.Equals("MODE_CHANGE"))
                    {
                        Mode = command.NewMode;
                    }
                    else
                    {
                        throw new ArgumentException(command.CommandType, "Valid command type required.");
                    }
                }
            }
            else
            {
                throw new ArgumentNullException("Message contains no valid commands.");
            }
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }
    }
}
