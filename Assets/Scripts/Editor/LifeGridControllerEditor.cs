using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEditor;
[CustomEditor(typeof(LifeGridController))]
public class LifeGridControllerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LifeGridController lifeGridController = (LifeGridController)target;

        if (GUILayout.Button("Add Life Image"))
            lifeGridController.AddLifeImage();

        if (GUILayout.Button("Refresh Life Images"))
            lifeGridController.RefreshLifeImages(lifeGridController.NumOfLives);
    }
}
