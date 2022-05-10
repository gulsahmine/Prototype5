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
        gameOverText.gameObject.SetActive(true);//game over yazýsýný setactive ile ortaya çýkarýyoruz
        isGameActive = false;    
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);//aktif olan scene yeniden baþlat
    }
    public void StartGame(int difficulty)
    {

        isGameActive = true;
        score = 0;
        spawnRate /= difficulty;//obje üretme hýzýný zorluk derecesine bölüyoruz.yani zorluk arttýkça daha kýsa aralýklarla obje üretecek

        StartCoroutine(spawnTarget());
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);//oyun baþladýðýnda title yok olsun
    }
}
