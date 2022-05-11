using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public interface ITest
{
    
}

public class Test : MonoBehaviour, ITest
{
    [SerializeReference] private ITest test;

    [MenuItem("File/AA")]
    public static void Init()
    {
        var test = FindObjectOfType<Test>();

        var bb = new BB
        {
            A = 1,
            B = 2,
        };

        test.test = bb;
        EditorUtility.SetDirty(test);
    }
}

[System.Serializable]
class BB : ITest
{
    public int A;
    public int B;
}
