using System.Linq.Expressions;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    Vector3 lastPosition;
    float size;
    public GameObject platform;
    public GameObject diamonds;
    public bool gameOver;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = platform.transform.position;
        size = platform.transform.localScale.x;     // non serve farlo per z perchè sono uguali
        gameOver = false;

        for(int i = 0; i < 20; i++) {
            SpawnPlatforms();
        }


    }

    public void StartSpawning() {
        InvokeRepeating("SpawnPlatforms",0.1f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.gameOver) {
            CancelInvoke("SpawnPlatforms");
        }
    }

    /*
    Crea randomicamente nuove piattaforme o sull'asse x o sull'asse z
    */
    void SpawnPlatforms() {
        if(gameOver) {
            return;
        }
        
        int rdm = Random.Range(0,6);
        if (rdm < 3) {
            SpawnX();
        }
        else if(rdm >= 3) {
            SpawnZ();
        }
    }

    /*
    Crea una nuova piattaforma lungo l'asse x
    */
    void SpawnX() {

        Vector3 position = lastPosition;
        position.x += size;
        lastPosition = position;
        Instantiate(platform,position,Quaternion.identity); // crea la piattaforma spostando la x senza rotazione

        int rdm = Random.Range(0,4);

        if(rdm < 1) {
            Instantiate(diamonds,new Vector3(position.x,position.y+1,position.z), diamonds.transform.rotation);     // crea diamante sulla piattaforma
        }
    }

    /*
    Crea una nuova piattaforma lungo l'asse z
    */
    void SpawnZ() {

        Vector3 position = lastPosition;
        position.z += size;
        lastPosition = position;
        Instantiate(platform,position,Quaternion.identity); // crea la piattaforma spostando la z senza rotazione

        int rdm = Random.Range(0,4);

        if(rdm < 1) {
            Instantiate(diamonds,new Vector3(position.x,position.y+1,position.z), diamonds.transform.rotation);     // crea diamante sulla piattaforma
        }

    }
}
