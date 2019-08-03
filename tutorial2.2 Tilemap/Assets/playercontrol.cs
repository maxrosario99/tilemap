using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playercontrol : MonoBehaviour
{
    private Rigidbody2D rb2d;

    private int score;
    public float speed;

    public AudioClip Jumpclip;

    public AudioClip Winclip;

    public AudioSource musicSource;

    public AudioClip BGMusic;

    public GameObject Door;

    public float jumpForce; 

    public Text ScoreText;

    public Text gorighttext;
    
    public Text WinText;

    public Text LiveText;

    private int lives;

    public Text losetext;

    public GameObject player;

    public GameObject LevelWall;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        score = 0;

        WinText.text = "";
        lives = 3;
        SetLivesText ();
        losetext.text = "";
        gorighttext.text = "";
        musicSource.clip = BGMusic;
        musicSource.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z = 0;
        transform.position = pos;

        if (Input.GetKey("escape"))
            Application.Quit();

    }
    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");

        Vector2 movement = new Vector2(moveHorizontal, 0);

        rb2d.AddForce(movement * speed);

      if(Input.GetKey(KeyCode.LeftArrow))
       {
           GetComponent<SpriteRenderer> ().flipX = true;
           GetComponent<Animator>().SetBool ("isRunn", true);
    
       } else {
           GetComponent<Animator>().SetBool ("isRunn", false);
       }
       if(Input.GetKey(KeyCode.RightArrow))
       {
           GetComponent<SpriteRenderer> ().flipX = false;
           GetComponent<Animator>().SetBool ("isRunn", true);

       } else {
           GetComponent<Animator>().SetBool ("isRunn", false);
       }


       

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("Coin"))
        {
            other.gameObject.SetActive (false);
            score = score + 1;
            SetScoreText ();
        }
        if (other.gameObject.CompareTag ("enemy"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }
         if (other.gameObject.CompareTag ("shot"))
        {
            other.gameObject.SetActive (false);
            lives = lives - 1;
            SetLivesText ();
        }
        
        if (other.gameObject.CompareTag ("Speedup"))
        {
            speed = 18f;
        }
    }
     void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.collider.tag == "Ground")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                 musicSource.clip = Jumpclip;
                musicSource.Play();
                GetComponent<Animator>().SetBool ("isJump", true);
            }
        }
        if(collision.collider.tag == "Platform")
        {
            if(Input.GetKey(KeyCode.UpArrow))
            {
                rb2d.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
                musicSource.clip = Jumpclip;
                musicSource.Play();
                 GetComponent<Animator>().SetBool ("isJump", true);
            }

        }
        
    }
    void SetScoreText()
    {
        ScoreText.text = "Score: " + score.ToString ();
        if (score == 8) 
            Door.SetActive(true);
            Destroy(LevelWall);
            lives = 3;

        if (score == 12){
            WinText.text = "You Win!";
            musicSource.clip = Winclip;
            musicSource.Play();
        }


    }
    void SetLivesText()
    {
        LiveText.text = "Lives: " + lives.ToString ();
        if (lives == 0)
        {
            losetext.text = "You Lose!";
            SceneManager.LoadScene("SampleScene");
        }

             
            
    }


    
}
