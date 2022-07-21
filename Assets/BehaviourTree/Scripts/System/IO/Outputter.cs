using System.Text;
using System.IO;
using BehaviourTree.Data;

namespace BehaviourTree.IO
{
    public class Outputter
    {
        public static void SetLog(BehaviourTreeUserData userData, string log)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(log);
            builder.Append("\n");

            UnityEngine.Debug.Log(builder.ToString());

            using (FileStream stream = File.Open(userData.IOPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                using (StreamReader reader = new StreamReader(stream))
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    string preString = reader.ReadToEnd();
                    writer.WriteLine(builder.ToString());
                    stream.Position = 0;
                    writer.WriteLine(preString);
                }
            }
        }
    }
}