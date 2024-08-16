using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public GameObject ball;
    Vector3 offset;    // distanza tra camera e palla
    public float rate;    // ogni quanto la camera cambia posizione per seguire la palla
    public bool gameOver;

    // Start is called before the first frame update
    void Start() {
        offset = ball.transform.position - transform.position;  // posizione di partenza
        gameOver = false;
    }

    // Update is called once per frame
    void Update() {
        if(!gameOver) {
            Follow();
        }
    }

    /*
    Crea un movimento fluido della camera nel seguire la palla
    */
    void Follow() {
        Vector3 pos = transform.position;   // posizione inziale
        Vector3 target = ball.transform.position - offset;   // posizione finale
        pos = Vector3.Lerp(pos,target,rate*Time.deltaTime);   // aggiornamento
        transform.position = pos;   // nuova posizione iniziale
    }
}
