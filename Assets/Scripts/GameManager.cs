using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;     // unica istanza del GameManager 
    public bool gameOver;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    Questa funzione serve ad avviare la partita
    */
    public void StartGame() {
        UIManager.instance.GameStart();     // l'UIManager viene settato in modalità "partita avviata"
        ScoreManager.instance.StartScore();     // stessa cosa per lo ScoreManager (inizia a tenere conto del punteggio)
        GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();     // vengono create piattaforme
    }

    /*
    Questa funzione serve a chiudere la partita in game over
    */
    public void GameOver() {
        UIManager.instance.GameOver();      // l'UIManager viene settato in modalità "game over"
        ScoreManager.instance.StopScore();      // stessa cosa per lo ScoreManager (valuta se c'è nuovo high score)
        gameOver = true; 
    }
}
