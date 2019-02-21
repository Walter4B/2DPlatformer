using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PauseButton : MonoBehaviour
{
    public UnityEvent OnTogglePause;
    /*
    void Awake()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(TogglePause);
    }
    */

    public void TogglePause()
    {
        OnTogglePause.Invoke();

        Time.timeScale = Time.timeScale == 0f ? 1f : 0f;
    }
}
