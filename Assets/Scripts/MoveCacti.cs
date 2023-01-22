using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCacti : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
