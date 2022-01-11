using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handleMissileDestroy : MonoBehaviour
{
    
    private fireMissiles missileLauncherScriptRef;
    // Start is called before the first frame update
    void Start(){
        missileLauncherScriptRef = GameObject.Find("MissileLauncher").GetComponent<fireMissiles>();
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Missile")){
            Destroy(other.gameObject);
            missileLauncherScriptRef.missileLive = false;
        }
    }
}
