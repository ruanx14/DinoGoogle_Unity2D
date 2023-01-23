using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    // Start is called before the first frame update

    public float addSpeed = 1f;
    public float speed = 4.5f;
    public float maxSpeed = 10f;

    private void Update()
    {
        speed = Mathf.Clamp(
            speed + addSpeed * Time.deltaTime,
            0,
            maxSpeed
            );
    }
}
