using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealthManager : MonoBehaviour
{
    [SerializeField]
    public int MaxNumOfLives = 3;
    public int NumOfLives = 3;

    public float LastTimeHit = 0;
}
