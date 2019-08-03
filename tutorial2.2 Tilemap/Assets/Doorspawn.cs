using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Doorspawn : MonoBehaviour
{
    public GameObject sp1, sp2;
    public static bool canTransport;
    // Start is called before the first frame update
    void Start()
    {
        canTransport = true;
        sp1 = this.gameObject;
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D trig)
    {
        if (canTransport == true){
            trig.gameObject.transform.position = sp2.gameObject.transform.position;
            canTransport = false;
        }
    }
    void OnTriggerExit2D(Collider2D trig) {
        canTransport = true;
    }
}
