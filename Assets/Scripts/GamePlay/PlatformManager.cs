using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformManager : MonoBehaviour
{

    Platforms platForm;
    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        platForm.platform.transform.Translate(Vector3.left * (platForm.speed * Time.deltaTime));

    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Reset")
        {
           // Destroy(this.gameObject);
        }
    }
}
