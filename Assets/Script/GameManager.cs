using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public int score;
    public GameObject heart1, heart2, heart3;
    public int health = 3;
    public GameObject GameOver;
    public GameObject WonGame;
    private PaddleMovement PM;
    // Start is called before the first frame update
    void Start()
    {
        GameObject Paddle = GameObject.FindWithTag("Paddle");
        PM = Paddle.GetComponent<PaddleMovement>();

        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
        WonGame.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        switch(health) {
            case 3:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                GameOver.gameObject.SetActive(false);
                break;
            case 2:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(false);
                break;
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(false);
                break;
            default:
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                GameOver.gameObject.SetActive(true);
                Time.timeScale = 0;
                break;
        }

        BlockCheck();


    }

    public void AddScore() {
        score += 1;
        scoreText.text = "Score : " + score.ToString();
    }

    private void BlockCheck() {
        GameObject[] blockObject = GameObject.FindGameObjectsWithTag("Block");

        if(blockObject.Length == 0) {
            WonGame.gameObject.SetActive(true);
            Time.timeScale = 0;
        }

    }

    public void PlayAgain() {
        //PM.isBallNotStart = true;
        //Time.timeScale = 1;
        SceneManager.LoadScene("InGame");
        // Debug.Log("Go");
    }

    // private void ResetScore() {
    //     score = 0;
    //     scoreText.text = "Score : " + score.ToString();
    // }


}
