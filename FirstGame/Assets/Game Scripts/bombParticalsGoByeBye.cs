using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bombParticalsGoByeBye : MonoBehaviour
{
    // Start is called before the first frame update
    public float timer;
    private float time;
    
    void Start(){
        time = 0.0f;
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time > timer){
            Destroy(gameObject);
        }
    }
}
