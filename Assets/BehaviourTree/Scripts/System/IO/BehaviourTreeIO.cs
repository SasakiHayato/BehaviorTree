#if UNITY_EDITOR

using System;
using System.Collections.Generic;
using System.Linq;
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

        public static void DeleteFile()
        {
            List<Type> types = new List<Type>();

            types = AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(w => !w.IsClass && !w.IsAbstract)
                .ToList();
            
            types.ForEach(t => UnityEngine.Debug.Log(t.Name));
        }
    }
}
#endif
