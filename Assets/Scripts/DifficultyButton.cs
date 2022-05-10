using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButton : MonoBehaviour
{
    private Button button;
     GameManager gameManager;
    public int difficulty;
    
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        button = GetComponent<Button>();
        button.onClick.AddListener(SetDifficulty);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SetDifficulty() // hangi tu�a bas�ld���n� console da g�rece�iz
    {
        Debug.Log(gameObject.name + " was clicked ");
        gameManager.StartGame(difficulty);
    }
}
