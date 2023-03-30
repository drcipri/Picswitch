using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;


public class AssetHandler
{
    [OnOpenAsset()]
    public static bool OpenEditor(int instanceId, int line)
    {
        PuzzleDataSO puzzleDataSO = EditorUtility.InstanceIDToObject(instanceId) as PuzzleDataSO;
        if(puzzleDataSO != null)
        {
            SliceOrderWindow.Open(puzzleDataSO);
            return true;
        }
        return false;
    }
}

[CustomEditor(typeof(PuzzleDataSO))]
public class SliceOrder : Editor
{
    
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if(GUILayout.Button("Open Puzzle Data Editor"))
        {
            SliceOrderWindow.Open((PuzzleDataSO)target);
            
        }
    }

}
