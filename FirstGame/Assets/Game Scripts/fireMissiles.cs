using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMissiles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Missile;
    private float timer;
    public bool missileLive;

    void Start(){
        timer = 0.0f;
        missileLive = false;
        // Instantiate(bulletParticals, transform.position, transform.rotation);
    }
    void Update(){
        timer += Time.deltaTime;
        Debug.Log("Time" + timer);
        if(missileLive == false){
            Instantiate(Missile, transform.position, transform.rotation);
            missileLive = true;
        }
    //     bulletParticals.transform.position = transform.position;
    }
}
