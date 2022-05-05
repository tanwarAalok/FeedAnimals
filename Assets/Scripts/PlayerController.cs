using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public TextMeshProUGUI scoreText, highscoreText;
    public static int score;
    public float horizontalInput;
    public float speed = 20.0f;
    public float xRange = 12;

    [SerializeField] public static int health;

    public GameObject projectilePrefab;
    public GameObject lives, gameOverText;

    public List<GameObject> hearts, back;
    private int idx, idx2;

    public static bool check = false;



    void Start()
    {

        health = 3;
        idx2 = 0;
        idx = 2;
        score = 0;
        highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore").ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xRange){
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if(transform.position.x > xRange){
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }

        scoreText.text = "Score : " + score.ToString();

        
        if(health <= 0) {
            if(score > PlayerPrefs.GetFloat("Highscore"))
            {
                PlayerPrefs.SetFloat("Highscore", score);
                highscoreText.text = "Highscore : " + PlayerPrefs.GetFloat("Highscore");
            }
            gameOverText.SetActive(true);
        }

        if (check)
        {
            check = false;
            liveController();
        }
        
    }

    public void liveController()
    {
        if (idx >= 0)
        {
            hearts[idx].SetActive(false);
            idx--;
        }

        if(idx2 < 3)
        {
            back[idx2].SetActive(true);
            idx2++;
        }
    }




    
}
