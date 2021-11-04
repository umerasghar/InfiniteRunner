using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Obstacle 
{
    [SerializeField]
    private GameObject obstaclePrefab;
    [SerializeField]
    private string obstacleType;

    public GameObject ObstaclePrefab { get => obstaclePrefab; set => obstaclePrefab = value; }
    public string ObstacleType { get => obstacleType; set => obstacleType = value; }
}
