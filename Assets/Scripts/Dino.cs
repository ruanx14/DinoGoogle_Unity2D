using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dino : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forcaPulo = 600;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
            Walk();
    }
    private void Pular()
    {
        rb.AddForce(Vector2.up * forcaPulo);
    }
    private void Walk()
    {
        float h = Input.GetAxis("Horizontal");

        /*
        rb.velocity= rb.velocity * h;
        rb.velocity = new Vector2(
            h * 10f,
            rb.velocity.y
        );
        */

        /*
        Vector2 move = new Vector2(h * 1f * Time.deltaTime, 0);

        transform.Translate(move);
        */
    }
}
