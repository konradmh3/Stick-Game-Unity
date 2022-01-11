using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyPartsAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rigidbody2d;
    public int x;
    public int y;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d.velocity = new Vector2(x, y);
    }

    
}
