using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;
    public int score;
    public int highScore;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score",score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementScore() {
        score += 1;
    }

    /*
    Richiama periodicamente la funzione "IncrementScore"
    */
    public void StartScore() {
        InvokeRepeating("IncrementScore",0.1f,0.5f);    
    }

    /*
    Interrompe la chiamata periodica a "IncrementScore" e valuta se c'è un nuovo high score
    */
    public void StopScore() {
        CancelInvoke("IncrementScore");
        PlayerPrefs.SetInt("score",score);     // inserisce in memoria del dispositivo il valore della variabile score

        if(PlayerPrefs.HasKey("highScore")) {       // valuta se è gia presente una "variabile" highScore
            if(score > PlayerPrefs.GetInt("highScore")) {   // se la trova valuta se è stato fatto un nuovo high score
                PlayerPrefs.SetInt("highScore",score);
            }
        }
        else {
            PlayerPrefs.SetInt("highScore",score);      // altrimenti lo imposta per la prima volta
        }
    }
}
