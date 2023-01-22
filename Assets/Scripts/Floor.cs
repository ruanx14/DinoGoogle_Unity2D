using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    private float diferencaX = 25f, minX = -13f;
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if(transform.position.x <= minX)
        {
            transform.position = new Vector3(
                transform.position.x + diferencaX * 2,
                transform.position.y,
                transform.position.z
                );
        }
    }
}
