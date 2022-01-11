using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stallthenGoBoom : MonoBehaviour
{
    public float time;
    private float timer;
    public GameObject animations;
    private int bodyCounter;

    void Start()
    {
        timer = 0.0f;
        bodyCounter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        
        if(timer <= time && bodyCounter < 2){
            bodyCounter += 1;
            Instantiate(animations, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
