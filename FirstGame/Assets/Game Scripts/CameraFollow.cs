using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public int offset;

    private Player playerScriptReference;
    // Start is called before the first frame update
    void Start()
    {
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScriptReference.alive){
            transform.position = new Vector3(player.position.x, player.position.y, offset);
        }
    }
}
