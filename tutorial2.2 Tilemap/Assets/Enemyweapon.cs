using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyweapon : MonoBehaviour
{
    public float fireRate;
    public float Delay;
    public GameObject shot;
    public Transform shotSpawn;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating ("Fire", Delay, fireRate);
    }

    // Update is called once per frame
    void Fire ()
    {
        Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
    }
}
