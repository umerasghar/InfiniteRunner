using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public Obstacle obstacleSet;
    public static bool canDestroy;
    float measureseconds = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(canDestroy)
        Destroy(this.gameObject, 8f);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
