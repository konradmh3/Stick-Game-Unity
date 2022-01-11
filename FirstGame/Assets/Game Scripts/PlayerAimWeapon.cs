using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAimWeapon : MonoBehaviour
{
    // Start is called before the first frame update
    // private Transform character;
    private Transform targetTransform;
    private Transform playerTransform;
    private Vector3 mouseScreenPosition;
    private Vector3 mouseWorldPosition;
    public bool m_facingLeft;

    private Player playerScriptReference;
    private void Awake(){
        // character = transform.Find("stick3");
        // targetTransform = GetComponent<Transform>();
        targetTransform = GameObject.Find("LeftArmSolver_Target").transform;
        playerTransform = GameObject.Find("stick3").transform;
        m_facingLeft = true;
        playerScriptReference = GameObject.Find("stick3").GetComponent<Player>();
    }
    
    
    private void FixedUpdate(){
        
        if(playerScriptReference.alive){
        mouseScreenPosition = Input.mousePosition;
        mouseWorldPosition = GetComponent<Camera>().ScreenToWorldPoint(new Vector3(mouseScreenPosition.x, mouseScreenPosition.y, GetComponent<Camera>().nearClipPlane+1)); 
        //The +1 is there so you don't overlap the object and the camera, otherwise the object is drawn "inside" of the camera, and therefore you're not able to see it!
       
        targetTransform.position = mouseWorldPosition;
        
        }
    }
    public void flip(){
        m_facingLeft = !m_facingLeft;
        playerTransform.Rotate(0f, 180f, 0f);
    }

    // public static Vector3 GetMouseWorldPosition(){
    //     Vector3 vec = GetMouseWorldPositionwithZ(Input.mousePosition, Camera.main);
    //     vec.z = 0f;
    //     return vec;
    // }
    // public static Vector3 GetMouseWorldPositionwithZ(){
    //     return GetMouseWorldPositionwithZ(Input.mousePosition, Camera.main);
    // }
    // public static Vector3 GetMouseWorldPositionwithZ(Camera worldCamera){
    //     return GetMouseWorldPositionwithZ(Input.mousePosition, worldCamera);
    // }
    // public static Vector3 GetMouseWorldPositionwithZ(Vector3 screenPosition, Camera worldCamera){
    //     Vector3 worldPosition = worldCamera.ScreenToWorldPoint(screenPosition);
    //     return worldPosition;
    // }
    
}
