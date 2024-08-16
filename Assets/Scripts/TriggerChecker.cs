using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerChecker : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /*
    Gestisce comportamento delle piattaforme quando la palla gli passa sopra
    */
    void OnTriggerExit(Collider col) {
        if(col.gameObject.tag == "PlayingBall") {
            Invoke("FallDown", 0.5f);   // ritarda la caduta
            FallDown ();   
        }
    }

    void FallDown() {
        GetComponentInParent<Rigidbody>().useGravity = true;    // cade verso il basso
        GetComponentInParent<Rigidbody>().isKinematic = false;  // non subisce altre forze

        Destroy (transform.parent.gameObject, 2f);  // dopo due secondi dalla caduta viene distrutta la piattaforma
    }
}
