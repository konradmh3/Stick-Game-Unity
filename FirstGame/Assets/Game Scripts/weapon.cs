using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform firePoint;
    public GameObject bulletPrefab;

    private Player playerScriptReference;

    // Update is called once per frame
    void Start(){
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
    }
    void Update()
    {
        if (playerScriptReference.alive){
        if(Input.GetMouseButtonDown(0)){
            shootBullet();
        }
        }
    }
    void shootBullet(){
        //spawning an object
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
