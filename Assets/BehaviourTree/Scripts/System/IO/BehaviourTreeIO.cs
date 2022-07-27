#if UNITY_EDITOR

using System.Collections.Generic;
using System.IO;
using BehaviourTree.Data;

namespace BehaviourTree.IO
{
    public static class BehaviourTreeIO
    {
        static BehaviourTreeJsonMeditor _jsonMeditor;
        static List<string> _pathList;

        const string LogFilePath = "Assets/BehaviourTree/Log/";

        public static void Initialize()
        {
            _pathList = new List<string>();
            _jsonMeditor = new BehaviourTreeJsonMeditor();

            IOPathModel model = _jsonMeditor.Read();

            if (model.DataArray.Length > 0)
            {
                DeleteFile(model);
            }
        }

        public static void CreateFile(string userPath, out string createPath)
        {
            string path = Path.Combine(LogFilePath, $"{userPath}_Log.txt");
            StreamWriter stream = File.CreateText(path);

            stream.Dispose();

            createPath = path;

            _pathList.Add(path);
        }

        static void DeleteFile(IOPathModel model)
        {
            
        }

        public static void Update()
        {
            _jsonMeditor.Write(_pathList);
        }
    }
}
#endif
