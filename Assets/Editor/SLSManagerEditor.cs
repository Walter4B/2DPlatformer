using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;

[CustomEditor(typeof(SLSManager))]
public class SLSManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SLSManager slsManager = (SLSManager)target;

        if (GUILayout.Button("Save PlayerStats"))
            slsManager.SavePlayerStats();

        if (GUILayout.Button("Load PlayerStats"))
            slsManager.LoadPlayerStats();
    }
}