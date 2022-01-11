using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorOpen : MonoBehaviour
{
    // Start is called before the first frame update
    private Player Finish;
    private bool doorOpen1;
    public Animator anim;

    void Start()
    {
        Finish = GameObject.Find("stick3").GetComponent<Player>();
    
    }

    // Update is called once per frame
    void Update()
    {
        doorOpen1 = Finish.FinishLevel;
        if(doorOpen1 == true){
            anim.SetBool("FinishLevel", true);
        }
        
    }
}
