using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class amountMovedOnStart : MonoBehaviour
{
    // Start is called before the first
    public float movementSpeed = 30;
    public GameObject door1;
    public GameObject door2;
    public GameObject exitSign1;
    public GameObject exitSign2;
    // private Rigidbody rb;
    private Vector3 endPosition = new Vector3(881.3471069335938f,170.3597412109375f,90.0f);
    private Vector3 endPosition2 = new Vector3(481.138671875f,170.3597412109375f,90.0f);
    // Use this for initialization
    // void Start() {
        // rb = GetComponent<Rigidbody>();
    // }
 
    // Update is called once per frame
    void Update() {
        if(door1.transform.position != endPosition) {
            door1.transform.position = Vector3.MoveTowards(door1.transform.position, endPosition, movementSpeed * Time.deltaTime);
            door2.transform.position = Vector3.MoveTowards(door2.transform.position, endPosition2, movementSpeed * Time.deltaTime);
            exitSign1.transform.position = new Vector3(door1.transform.position.x, exitSign1.transform.position.y, exitSign1.transform.position.z);
            exitSign2.transform.position = new Vector3(door2.transform.position.x, exitSign2.transform.position.y, exitSign2.transform.position.z);
        }
    }
    
}
