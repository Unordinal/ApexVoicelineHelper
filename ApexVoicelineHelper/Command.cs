using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApexVoicelineHelper
{
    public class Command
    {
        public string[] Args { get; private set; }
        public string Comment { get; set; }
        public Command(string[] args) => Args = args;
        public Command(string[] args, string comment)
        {
            Args = args;
            Comment = comment;
        }

        public static Command Parse(string strCmd)
        {
            List<string> args = new List<string>();
            StringBuilder strBuild = new StringBuilder(80);
            bool outOfQuotes = true;
            bool comment = false;
            string strComment = "";
            foreach (var c in strCmd)
            {
                if (comment)
                {
                    strBuild.Append(c);
                    continue;
                }
                else if (c == ' ' && outOfQuotes)
                {
                    if (strBuild.Length > 0)
                        args.Add(strBuild.ToString());
                    strBuild.Clear();
                }
                else if (c == '/' && strBuild.ToString().EndsWith("/"))
                {
                    strBuild.Clear();
                    comment = true;
                }
                else if (c == '"')
                    outOfQuotes = !outOfQuotes;
                else
                    strBuild.Append(c);
            }
            if (strBuild.Length > 0)
            {
                if (comment)
                    strComment = strBuild.ToString().Trim();
                else
                    args.Add(strBuild.ToString());
            }

            return new Command(args.ToArray(), strComment);
        }

        public override string ToString()
        {
            List<string> args = new List<string>();
            args.AddRange(Args.Select(a => a.Any(char.IsWhiteSpace) ? "\"" + a + "\"" : a));
            return string.Join(" ", args) + (string.IsNullOrWhiteSpace(Comment) ? "" : " // " + Comment);
        }
    }
}
