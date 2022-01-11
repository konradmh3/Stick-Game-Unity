using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuGunFollow : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform stick3Target;
    public Transform stick4Target;
    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;
    
    void Start(){
        stick3Target = stick3Target.transform;
        stick4Target = stick4Target.transform;
    }

    void FixedUpdate()
    {
        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, GetComponent<Camera>().nearClipPlane+1));  
        stick3Target.position = mouseWorldPosition;
        stick4Target.position = mouseWorldPosition;
    }
}
