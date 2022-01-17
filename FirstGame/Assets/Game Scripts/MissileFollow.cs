using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileFollow : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector2 pointerTowardsStick;
    public GameObject playerObject;
    public Rigidbody2D rb;
    private Player playerScriptReference;
    private float rotationOfMissile;
    public float m_Thrust = 1.5f;

    // The target marker.
    

    // Angular speed in radians per sec.

    // private float timer;

    
    // Update is called once per frame
    // void Update()
    // {
        
        // transform.Translate(pointerTowardsStick*1/10);

    // }
    void Start(){
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
        pointerTowardsStick = new Vector2(playerObject.transform.position.x - transform.position.x, playerObject.transform.position.y - transform.position.y);
        pointerTowardsStick.Normalize();
        playerObject = GameObject.Find("stick3");
        // rb.AddForce(transform.up * m_Thrust);
        // rb.velocity = transform.right * speed;
        
        // Instantiate(bulletParticals, transform.position, transform.rotation);
    }
    void Update(){
        if(playerScriptReference.alive){
            Debug.Log(playerObject.transform.position);
            pointerTowardsStick = new Vector2(playerObject.transform.position.x - transform.position.x, playerObject.transform.position.y - transform.position.y);
            pointerTowardsStick.Normalize();
            rotationOfMissile = Mathf.Rad2Deg*Mathf.Atan(pointerTowardsStick.y/pointerTowardsStick.x);
            if(pointerTowardsStick.y > 0 && rotationOfMissile < 0){
                rotationOfMissile += 180;
            }
            if(pointerTowardsStick.y < 0 && rotationOfMissile > 0){
                rotationOfMissile -= 180;
            }
            transform.rotation = Quaternion.Euler(0, 0, rotationOfMissile);
            // rb.velocity = transform.right * speed;
            if(rb.velocity.magnitude <= 30f){
                rb.AddForce(transform.right * m_Thrust);
            }
            
        
            // Debug.Log(rotationOfMissile);

        }
        
    }
    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("bullet")){
            Destroy(gameObject);
            
        }
        if(other.gameObject.CompareTag("Player")){
            playerScriptReference.Health-=30;
            Destroy(gameObject);

        }
        if(other.gameObject.CompareTag("platfroms")){
            Destroy(gameObject);

        }
    }
    //     inverseTAN(y/x) gives angle needed to point towards player
    //     bulletParticals.transform.position = transform.position;
    
}
