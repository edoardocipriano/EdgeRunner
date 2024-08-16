using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;

    [SerializeField]
    private float speed;    // velocità scalare della palla
    bool started;   // bool -> gioco inziato
    bool gameOver;

    Rigidbody rb;

    void Awake() {
        rb = GetComponent<Rigidbody> ();    // componente Rigidbody di PlayingBall
    }
    // Start is called before the first frame update
    void Start() {

        started = false;
        gameOver = false;

    }

    // Update is called once per frame
    void Update() {

        /*
        Il gioco non inizia fino a quando il giocatore non tocca lo schermo
        */
        if(!started) {
            if(Input.GetMouseButtonDown(0)) {
                rb.velocity = new Vector3(speed,0,0); // velocità vettoriale lungo asse x con velocità scalare "speed"
                started = true;

                GameManager.instance.StartGame();   // viene avviato il gioco
            }
        }

        /*
        Viene valutato se la palla cade dal tracciato
        */
        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if(!Physics.Raycast(transform.position, Vector3.down, 1f)) {
            gameOver = true;
            rb.velocity = new Vector3(0,-100f,0);    // cade verso il basso

            Camera.main.GetComponent<CameraFollow>().gameOver = true;   // la camera non segue più la palla

            GameManager.instance.GameOver();    // viene chiamato il GameOver nel game manager
        }
        
        /*
        Viene monitorato se il giocatore tocca o meno lo schermo per cambiare direzione
        */
        if(Input.GetMouseButtonDown(0) && !gameOver) {
            SwitchDirection ();
        }
    }

    /*
    Questa funzione serve a cambiare direzione tra asse x ed asse z (unici possibili) 
    */
    void SwitchDirection() {

        if(rb.velocity.z > 0) {
            rb.velocity = new Vector3(speed,0,0);   // solo componente x
        } else if (rb.velocity.x > 0) {
            rb.velocity = new Vector3(0,0,speed);   // solo componente z
        }

    }

    /*
    Questa funzione serve a "raccogliere" i diamanti se la palla ci passa attraverso
    */
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Diamond") {

            GameObject part = Instantiate(particle, col.gameObject.transform.position,Quaternion.identity) as GameObject;   // crea particelle
            Destroy (col.gameObject);   // distrugge diamante istantaneamente
            Destroy (part,1f);  // distrugge particelle dopo 1 secondo

        }
    }
}
