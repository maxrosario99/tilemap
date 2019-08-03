using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerascript : MonoBehaviour{
 
 public Transform player;
 public float distance = 10f;


    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.position + new Vector3 (distance, 0, 0);
    }
    
}
