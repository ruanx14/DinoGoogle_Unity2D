using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    private Rigidbody2D rb;
    public float forcaPulo = 600;

    public LayerMask layerFloor;
    private bool verifyFloor;
    public float distanceFloor = 3f;


    private float score;
    public Text scoreText;

    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        //score = int.Parse(Time.time.ToString());
        //score = Mathf.FloorToInt(Time.time);
        score += Time.deltaTime * 3;
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
    }
    private void Pular()
    {
        if (verifyFloor)
        {
            rb.AddForce(Vector2.up * forcaPulo);
        }
    }
    private void FixedUpdate()
    {
        verifyFloor = Physics2D.Raycast(transform.position,Vector2.down, distanceFloor, layerFloor);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
