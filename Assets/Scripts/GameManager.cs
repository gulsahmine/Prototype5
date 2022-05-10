using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<GameObject> targets; //targetleri burda listeledik
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public Button restartButton;
    public GameObject titleScreen;
    private int score;
    public bool isGameActive;
    

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
    }
    IEnumerator spawnTarget()
    {
       while (isGameActive)
        {
        yield return new WaitForSeconds(spawnRate);
        int index=Random.Range(0, targets.Count);
        Instantiate(targets[index]);
           

        }
    }
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;

        scoreText.text = ("score : " + score);

    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);//game over yaz�s�n� setactive ile ortaya ��kar�yoruz
        isGameActive = false;    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//aktif olan scene yeniden ba�lat
    }
    public void StartGame(int difficulty)
    {

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;//obje �retme h�z�n� zorluk derecesine b�l�yoruz.yani zorluk artt�k�a daha k�sa aral�klarla obje �retecek

        StartCoroutine(spawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);//oyun ba�lad���nda title yok olsun
    }
}
