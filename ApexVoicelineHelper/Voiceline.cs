using System.Windows.Input;

namespace ApexVoicelineHelper
{
    public class Voiceline
    {
        public string Keybind { get => Command.Args[1]; }
        public int ID
        {
            get
            {
                int.TryParse(Command.Args[2].Split(' ')[1], out int id);
                return id;
            }
        }
        public string Name { get => Command.Comment; }
        public Command Command { get; private set; }
        public Voiceline(Command bindCmd, string name)
        {
            Command = bindCmd;
            Command.Comment = name;
        }
        public Voiceline(string keybind, int id, string name)
        {
            Command = Command.Parse($"bind \"{keybind}\" \"ClientCommand_Quickchat {id}\"");
            Command.Comment = name;
        }

        public override string ToString() =>
            $"[{Keybind}]: {Name} ({ID})";
    }
}
