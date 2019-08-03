using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerScorescript : MonoBehaviour
{
    private float timeLeft = 120;
    public int playerScore = 0;

    public GameObject timeLeftUI;
    public GameObject playerScoreUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log (timeLeft);
        timeLeft -= Time.deltaTime;
        timeLeftUI.gameObject.GetComponent<Text>().text = ("Time Left: " + timeLeft);
        if (timeLeft < 0.1f) {
            SceneManager.LoadScene("SampleScene");
        }
    }
    void OnTriggerEnter2D (Collider2D trig) {
        CountScore ();
    }
    void CountScore () {
        playerScore = playerScore + (int)(timeLeft * 10);
        Debug.Log (playerScore);
    }
}
