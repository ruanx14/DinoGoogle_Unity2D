 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCacti : MonoBehaviour
{
    public Vector2 direction;

    private Game gameScript;
    private void Start()
    {
        gameScript = GameObject.Find("Game").GetComponent<Game>();
    }
    private void Update()
    {
        transform.Translate(direction * gameScript.speed * Time.deltaTime);
    }
}
