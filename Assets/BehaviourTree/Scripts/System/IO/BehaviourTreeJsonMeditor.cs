using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using BehaviourTree.Data;

namespace BehaviourTree.IO
{
    public class BehaviourTreeJsonMeditor
    {
        const string JsonPath = "Assets/BehaviourTree/Log/UserPath.json";

        public void Write(List<string> list)
        {
            IOPathModel model = CreateModel(list);
            string json = JsonUtility.ToJson(model);

            StreamWriter writer = new StreamWriter(JsonPath);
            writer.WriteLine(json);
            writer.Flush();
            writer.Close();
        }

        IOPathModel CreateModel(List<string> pathList)
        {
            IOPathModel model = new IOPathModel();
            int length = pathList.Count;

            model.DataArray = new PathData[length];

            for (int index = 0; index < length; index++)
            {
                model.DataArray[index] = new PathData();
                model.DataArray[index].Path = pathList[index];
            }

            return model;
        }
    }
}