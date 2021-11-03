using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
[Serializable]
public class GameComponents 
{
    [Header("GamePlay Components")]
    public Text gameStartCounter;
    public Text scoreCount;
    public Text gemCount;
    [Header("Obstacles")]
    public Transform obstaclePrefab;
}
