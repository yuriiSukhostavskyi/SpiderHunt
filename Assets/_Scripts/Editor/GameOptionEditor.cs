using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class GameOptionEditor : MonoBehaviour
{
    [CustomEditor(typeof(GameOption))]
    public class GameOptionsEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            GameOption myScript = (GameOption)target;
            if (GUILayout.Button("Load Level"))
            {
                myScript.SetLevel();
            }
        }
    }
}
