using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class Player : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    private Rigidbody2D rigidbody2d;
    public EdgeCollider2D jumpableSurface;
    public Collider2D myColider;
    private Animator anim;
    private CapsuleCollider2D collider2D;
    public bool alive;
    public bool m_facingLeft;
    public float velocity;
    public float Health;
    public GameObject deathlocation;
    public bool FinishLevel;
    public float delay  = 4f;
    float countdown;
    public int maxHealth = 100;
    public HealthBarScript healthBar;
    public bool doorUnlocked = false;
    private fireMissiles missileLauncherScriptRef;

    
    
    
    // Start is called before the first frame update
    void Start()
    {
        Health = maxHealth;
        countdown = delay;
        alive = true;
        collider2D = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        rigidbody2d = transform.GetComponent<Rigidbody2D>();
        // myColider = GetComponent<Collider2D>();
        rigidbody2d.freezeRotation = true;
        m_facingLeft = true;
        velocity = rigidbody2d.velocity.x;
        healthBar.SetMaxHealth(maxHealth);
        missileLauncherScriptRef = GameObject.Find("MissileLauncher").GetComponent<fireMissiles>();

    }

    // Update is called once per frame
    void Update()
    {
        if(alive){
        if (Input.GetKeyDown(KeyCode.Space) && groundCheck())
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, jumpVelocity);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && !groundCheck() && wallCheckR())
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x - 8f, jumpVelocity);
            
        }
        if (Input.GetKeyDown(KeyCode.Space) && !groundCheck() && wallCheck())
        {
            float jumpVelocity = 10f;
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x + 8f, jumpVelocity);
            
        }
         Movement();
         handleAnimations();
         flip();
         checkLiving();
         velocity = rigidbody2d.velocity.x;
         LoadNextLevel();
         healthBar.SetHealth(Health);
         if(FinishLevel != true){
            SubtractHealth(); 
         }
         
        }
    }
    void Movement()
    {
        float airAcceleration = 15f;
        float groundAcceleration = 30f;
        float maxSpeed = 20f;
        float currentSpeed = rigidbody2d.velocity.x;
 
        if (Input.GetKey(KeyCode.A) && !wallCheck())
        {
            
            if (groundCheck() && currentSpeed > -maxSpeed){
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x + ( -groundAcceleration * Time.deltaTime), rigidbody2d.velocity.y);
            }
            else if(!groundCheck() && currentSpeed > -maxSpeed){
                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x + ( -airAcceleration * Time.deltaTime), rigidbody2d.velocity.y);
                
            }

        }
        if (Input.GetKey(KeyCode.D) && !wallCheckR())
        {
            
            if (groundCheck() && currentSpeed < maxSpeed){
            rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x + (groundAcceleration * Time.deltaTime), rigidbody2d.velocity.y);
            }
            else if(!groundCheck() && currentSpeed < maxSpeed){
                    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x +  (airAcceleration * Time.deltaTime), rigidbody2d.velocity.y);
                
            }
        }
    
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            
            slidingCollider();

        }
        else{
       
            slidingCollider();
        }

        
        
           
    }
    private void SubtractHealth(){
        Health -= Time.deltaTime;
        Health -= Time.deltaTime;
        Health -= Time.deltaTime;
        Health -= Time.deltaTime;
        
    }
    
    private bool groundCheck()
    {
        float extraheighttext =.1f;
        RaycastHit2D raycastHit = Physics2D.Raycast(myColider.bounds.center, Vector2.down, myColider.bounds.extents.y + extraheighttext, platformLayerMask);
        Color rayColor;
        if(raycastHit.collider!=null){
            rayColor= Color.green;
        }else{
            rayColor = Color.red;
        }
        Debug.DrawRay(myColider.bounds.center, Vector2.down * (myColider.bounds.extents.y + extraheighttext), rayColor);
        // Debug.Log(raycastHit.collider);
        return raycastHit.collider != null;
    }
    private bool wallCheck(){
        float extraheighttext = .1f;
        RaycastHit2D raycastHi = Physics2D.Raycast(myColider.bounds.center, Vector2.left, myColider.bounds.extents.x + extraheighttext, platformLayerMask);
        Color rayColor;
        if(raycastHi.collider!=null){
            rayColor= Color.green;
        }else{
            rayColor = Color.red;
        }
        Debug.DrawRay(myColider.bounds.center, Vector2.left * (myColider.bounds.extents.x + extraheighttext), rayColor);
        // Debug.Log(raycastHi.collider);
        return raycastHi.collider != null;
    }
    private bool wallCheckR(){
        float extraheighttext = .1f;
        RaycastHit2D raycastHi = Physics2D.Raycast(myColider.bounds.center, Vector2.right, myColider.bounds.extents.x + extraheighttext, platformLayerMask);
        Color rayColor;
        if(raycastHi.collider!=null){
            rayColor= Color.green;
        }else{
            rayColor = Color.red;
        }
        Debug.DrawRay(myColider.bounds.center, Vector2.right * (myColider.bounds.extents.x + extraheighttext), rayColor);
        // Debug.Log(raycastHi.collider);
        return raycastHi.collider != null;
    }
    private void slidingCollider(){
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D)){
            collider2D.size = new Vector2(collider2D.size.x, 2.560745f);
            collider2D.offset = new Vector2(collider2D.offset.x, -0.9571123f);
        }
        else{
            collider2D.offset = new Vector2(collider2D.offset.x, 0f);
            collider2D.size = new Vector2(collider2D.size.x, 4.47497f);
        }
        
    }
    private void handleAnimations(){
        if ((GetComponent<Rigidbody2D>().velocity.x < -0.1  && Input.GetKey(KeyCode.A) || GetComponent<Rigidbody2D>().velocity.x > 0.1  && Input.GetKey(KeyCode.D)) && groundCheck()){
            
            anim.SetBool("isRunning", true);
            
        }else{  
            anim.SetBool("isRunning", false);
            
        }
        if(Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D) && Math.Abs(GetComponent<Rigidbody2D>().velocity.x) > .01 && groundCheck()){
            anim.SetBool("isSliding", true);
        }else{
            anim.SetBool("isSliding", false);
        }
        if(Input.GetKeyDown(KeyCode.Space) && (groundCheck() || wallCheck() || wallCheckR())){
            anim.SetBool("isJump", true);
        }else if(GetComponent<Rigidbody2D>().velocity.y < .01 && (!groundCheck() || !wallCheck() || !wallCheckR())){
            anim.SetBool("isJump", false);
        }
        if((wallCheckR() || wallCheck()) && !groundCheck() && GetComponent<Rigidbody2D>().velocity.y < .01){
            // anim.SetBool("isJump", false);
            anim.SetBool("isWallSlide", true);
        }else{
            anim.SetBool("isWallSlide", false);
        }
        
    }
    private void flip(){
        if(rigidbody2d.velocity.x < -.01 && m_facingLeft == false){
            transform.Rotate(0f, 180f, 0f);
            m_facingLeft = !m_facingLeft;
        }
        if(wallCheckR() && !groundCheck() && m_facingLeft != true){
            transform.Rotate(0f, 180f, 0f);
            m_facingLeft = !m_facingLeft;
        }
        if(rigidbody2d.velocity.x > .01 && m_facingLeft == true){
            transform.Rotate(0f, 180f, 0f);
            m_facingLeft = !m_facingLeft;
        }
        if(wallCheck() && !groundCheck() && m_facingLeft != false){
            transform.Rotate(0f, 180f, 0f);
            m_facingLeft = !m_facingLeft;
        }
        
        
    }
    void checkLiving(){
        if(Health <= 0){
            alive = false;   
        }
        Debug.Log(alive);
        if (alive == false){
            Instantiate(deathlocation, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Time")){
            Destroy(other.gameObject);
            if (Health <100){
                Health += 5;
            }
        }
        if(other.gameObject.CompareTag("Finish")){
            FinishLevel = true;

        }
        if(other.gameObject.CompareTag("DoorKey")){
            doorUnlocked = true;
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("Missile")){
            Destroy(other.gameObject);
            missileLauncherScriptRef.missileLive = false;
            Health -= 15;
        }
        
            
    }
    private void LoadNextLevel(){
        if(FinishLevel == true){
        countdown -= Time.deltaTime;
            if(countdown <= 0f){
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }
    }
    
    
}
