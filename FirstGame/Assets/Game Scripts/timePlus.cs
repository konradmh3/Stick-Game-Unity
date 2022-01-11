using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class timePlus : MonoBehaviour
{
    public Collider2D myCollider;
    private Collider2D playerCollider;

    private Player playerScriptReference;
    private Rigidbody2D playerRigid;
    // Update is called once per frame
    void Start()
    {
        playerCollider = GameObject.Find("stick3").GetComponent<Collider2D>();
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
        playerRigid = GameObject.Find("stick3").GetComponent<Rigidbody2D>();
    }
    // void Update()
    // {
    //     if(playerScriptReference.alive){
            
            // if(myCollider.IsTouching(playerCollider)){
            //     Debug.Log("Tick Tock");
            //     playerScriptReference.Health = playerScriptReference.Health + 5;
            //     Destroy(gameObject);
            // }
            
        
    
    // private void OnTriggerEnter2D(Collider2D other){
    //     if(other.gameObject.CompareTag("Time")){
    //         Destroy(other.gameObject);
    //     }
    // }
}
