using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1TextControll : MonoBehaviour
{
    // Start is called before the first frame update
    public float delay  = 4f;
    float countdown;

    void Start(){
        countdown = delay;
    }
    void Update()
    {
        countdown -= Time.deltaTime;
        if(countdown <= 0f){
            Destroy(gameObject);
        }
    }
}
