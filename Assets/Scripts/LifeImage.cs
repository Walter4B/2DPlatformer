using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class LifeImage : MonoBehaviour
{
    public Image Life;

    public Sprite LifeFullSprite;
    public Sprite LifeEmptySprite;

        public void SetActive(bool value)
    {
        //Life.enabled = value;
        /*
        if (value)
            Life.sprite = LifeFullSprite;
        else
            Life.sprite = LifeEmptySprite;
            */

        // ovo je if()
        Life.sprite = value ? LifeFullSprite : LifeEmptySprite;
    }

}

#if UNITY_EDITOR
[CustomEditor(typeof(LifeImage))]
public class LifeImageEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        LifeImage lifeImage = (LifeImage)target;

        if (GUILayout.Button("Active"))
            lifeImage.SetActive(true);

        if (GUILayout.Button("Deactivate"))
            lifeImage.SetActive(false);
    }
}
#endif