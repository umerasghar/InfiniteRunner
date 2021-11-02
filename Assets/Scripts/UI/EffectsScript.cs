using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectsScript : MonoBehaviour
{

    float timePassed = 0f;
    float changeTime = 1f;
    Color targetColor;
      //  componentColor;
    //float startTime = 0;
    //public bool repeat;
    //public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
       // componentColor = UIManager.instance.uiComponents.logo.color;
       // startTime = Time.deltaTime;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;
        if (timePassed >= changeTime)
        {

            targetColor = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
            UIManager.instance.uiComponents.logo.color = targetColor;
             //if (!repeat)
             //{
             //    float t = (Time.time - startTime) * speed;       
             //    UIManager.instance.uiComponents.logo.color = Color.Lerp(componentColor, targetColor, t);
             //}
             //else
             //{
             //    float t = Mathf.Sin((Time.time - startTime) * speed);
             //    UIManager.instance.uiComponents.logo.color = Color.Lerp(componentColor, targetColor, t);
             //}
             //componentColor = UIManager.instance.uiComponents.logo.color;
             timePassed = 0f;
        }
    }
    
}
