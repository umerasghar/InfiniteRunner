using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    public Platforms platForm;
    float startPos;
    float length;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPos = platForm.platform.transform.position.x;
        length = platForm.platform.GetComponent<SpriteRenderer>().bounds.size.x;

    }
    // Update is called once per frame
    void Update()
    {
        float temp = (Camera.main.transform.position.x * (1 - parallaxEffect));
        float dist= (Camera.main.transform.position.x * parallaxEffect);
        platForm.platform.transform.position = new Vector3(startPos + dist, 0f, 0f);
        if (temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
        //  platForm.platform.transform.Translate(Vector3.left * (platForm.speed * Time.deltaTime));
        //if (platForm.platform.transform.localPosition.x < -1916f)
        //{
        //    platForm.platform.transform.localPosition = startpos;
        //}

    }
    //void OnTriggerEnter2D(Collider2D collider)
    //{
    //    if (collider.tag == "Reset")
    //    {
    //        platForm.platform.transform.position = startpos;
    //    }
    //}
}
