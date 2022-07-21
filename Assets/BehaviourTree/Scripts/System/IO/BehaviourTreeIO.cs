#if UNITY_EDITOR

using System.IO;

namespace BehaviourTree.IO
{
    public static class BehaviourTreeIO
    {
        const string FilePath = "Assets/BehaviourTree/Log/";

        public static void CreateFile(string userPath, out string createPath)
        {
            string path = Path.Combine(FilePath, $"{userPath}_Log.txt");
            StreamWriter stream = File.CreateText(path);

            stream.Dispose();

            createPath = path;
        }
    }
}
#endif
