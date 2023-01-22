using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Dino : MonoBehaviour
{
    //Ruan Barroso
    //pulo
    private Rigidbody2D rb;
    public float forcaPulo = 600;

    //checando o chao
    public LayerMask layerFloor;
    private bool verifyFloor;
    public float distanceFloor = 3f;

    //score na tela
    private float score;
    private float highscore;    
    public Text scoreText;
    public Text highscoreText;

    //animator walking + turn down
    public Animator animatorComponent;

    //audios sources
    public AudioSource jumpAudioSource;
    public AudioSource hundredScoreAudioSource;
    public AudioSource endGameAudioSource;

    private void Start()
    {
       rb = GetComponent<Rigidbody2D>();
       highscore = PlayerPrefs.GetFloat("highscore");
       highscoreText.text = $"HI {Mathf.FloorToInt(PlayerPrefs.GetFloat("highscore"))}";
    }

    // Update is called once per frame
    private void Update()
    {
        //score = int.Parse(Time.time.ToString());
        //score = Mathf.FloorToInt(Time.time);
        score += Time.deltaTime * 10;
        scoreText.text = Mathf.FloorToInt(score).ToString();
        if (Mathf.FloorToInt(score) > 0 && Mathf.FloorToInt(score) % 100 == 0 && !hundredScoreAudioSource.isPlaying)
        {
            hundredScoreAudioSource.Play();
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            Pular();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TurnDown();
        }else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            animatorComponent.SetBool("Walking", false);
        }
    }
    private void Pular()
    {
        if (verifyFloor)
        {
            rb.AddForce(Vector2.up * forcaPulo);
            jumpAudioSource.Play();
        }
    }
    private void TurnDown()
    {
        animatorComponent.SetBool("Walking", true);
    }
    private void FixedUpdate()
    {
        verifyFloor = Physics2D.Raycast(transform.position,Vector2.down, distanceFloor, layerFloor);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if(score>highscore)
            {
                highscore = score;
                PlayerPrefs.SetFloat("highscore", highscore);
            }
            endGameAudioSource.Play();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
