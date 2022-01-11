using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb2 : MonoBehaviour
{
    public Collider2D myCollider;
    private Collider2D characterCollider; 
    public ParticleSystem bombParticals;
    private GameObject player;

    private int BombPower;

    private Rigidbody2D playerRigid;

    private Player playerScriptReference;
    // Start is called before the first frame update
    void Start()
    {
        // myCollider = GameObject.Find("bomb").GetComponent<Collider2D>();
        characterCollider = GameObject.Find("stick3").GetComponent<CapsuleCollider2D>();
        // bombParticals = GameObject.Find("Particle System").GetComponent<ParticleSystem>();
        playerRigid = GameObject.Find("stick3").GetComponent<Rigidbody2D>();
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
        BombPower = 10;
        player = GameObject.Find("stick3");
        
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScriptReference.alive){
            if(myCollider.IsTouching(characterCollider)){
                Instantiate(bombParticals, transform.position, transform.rotation);
                Debug.Log("Boom");
                playerRigid.velocity = new Vector2((player.transform.position.x-myCollider.transform.position.x) * BombPower, (player.transform.position.y-myCollider.transform.position.y) * BombPower);
                Destroy(gameObject);
                damage();
            }
        }
        
    }
    void damage()
    {
        playerScriptReference.Health = playerScriptReference.Health - 5;
        
    }

}
