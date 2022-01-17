using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireMissiles : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Missile;
    
    private float timer;
     
    public Transform launcherTransform;

    void Start(){
        timer = 0.0f;


        // Instantiate(bulletParticals, transform.position, transform.rotation);
    }
    void Update(){
        if(timer % 5.0 > -0.005 && timer % 5.0 < 0.005){
            Instantiate(Missile, launcherTransform.position, launcherTransform.rotation);
        }
        timer += Time.deltaTime;
        Debug.Log("Time" + timer);
        
    //     bulletParticals.transform.position = transform.position;
    }
}
