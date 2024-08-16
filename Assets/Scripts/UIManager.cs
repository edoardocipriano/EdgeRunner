using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{

    public static UIManager instance;
    public GameObject edgeRunnerPanel;
    public GameObject gameOverPanel;
    public GameObject tapText;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore1;
    public TextMeshProUGUI highScore2;

    void Awake() {
        if (instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore").ToString();
    }

    /*
    Gestisce l'animazione della scritto "Tap to Start"
    */
    public void GameStart() {
        tapText.SetActive (false);  // viene disabilitato il blinking
        edgeRunnerPanel.GetComponent<Animator>().Play("PanelUp");   // viene abilitato lo spostamento verso il basso con fadeing
    }

    /*
    Gestisce animazione del pannello per il game over
    */
    public void GameOver () {
        score.text = PlayerPrefs.GetInt("score").ToString();    // nuovo punteggio
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();   // high score
        gameOverPanel.SetActive (true);     // attiva l'animazione
    }

    /*
    Ritorna alla scena iniziale quando viene premuto il pulsante RESET
    */
    public void Reset() {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
