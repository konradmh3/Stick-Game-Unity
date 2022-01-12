using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed = 20f;
    public Rigidbody2D rb;
    private float timer;

    
    // public ParticleSystem bulletParticals;
    // Update is called once per frame
    void Start(){
        rb.velocity = transform.right * speed;
        timer = 0.0f;
        // Instantiate(bulletParticals, transform.position, transform.rotation);
    }
    void Update(){
        timer += Time.deltaTime;
        // Debug.Log("Time" + timer);
        if(timer > 5){
        Destroy(gameObject);
        }
    //     bulletParticals.transform.position = transform.position;
    }
    void OnTriggerEnter2D (Collider2D collider)
    {
        // Debug.Log(collider.name);
        if(!collider.gameObject.CompareTag("Player")){
            Destroy(gameObject);
        }
       
        
    }
}
