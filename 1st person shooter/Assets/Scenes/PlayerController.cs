using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
        [Header("Stats")]

        public int curHP;
        public int maxHP;

        [Header("Movement")]

        public float moveSpeed;
        public float JumpForce;

        [Header("camera")]
        public float lookSensativity;
        public float maxLookX;
        public float minLookX;
        private float rotX;

    
        [Header("components")]
        private Camera cam;
        private Rigidbody rb;

        private Weapon weapon;

    void Awake()  {
        //get components 
        cam = Camera.main;
        rb = GetComponent<Rigidbody>();

        weapon =GetComponent<Weapon>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // update is called once per frame
    void Update (){
        Move();
        CamLook();
        //jump 
        if(Input.GetButtonDown ("Jump"))
            Jump();
            // fire 
            if(Input.GetButton("Fire1"))
            {
                if(weapon.CanShoot())
                    weapon.Shoot();
            }
        }
    void Move()  {
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;
        // putting movement on rigidbody 
        Vector3 dir = transform.right * x + transform.forward  * z;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    void Jump(){
        // Cast ray to the ground
        Ray ray = new Ray(transform.position, Vector3.down);
        // Check Ray length to jump 
        if(Physics.Raycast(ray, 1.1f))
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
    }

    void CamLook() {
        float y = Input.GetAxis("Mouse X") * lookSensativity;
        rotX += Input.GetAxis("Mouse Y") * lookSensativity;

        //clamp the verticle rotation of camera 
        rotX = Mathf.Clamp(rotX, minLookX, maxLookX);

        //applying the rotation to camera 
        cam.transform.localRotation = Quaternion.Euler(-rotX, 0, 0);
        transform.eulerAngles += Vector3.up * y;

    }

    public void TakeDamage(int damage)
    {
        curHP -= damage;
        if(curHP <= 0) 
        Die();
    }
    
    void Die() {
        print("Homeboy sucks, basically offed himself");
    }

    public void GiveHealth(int amountToGive) 
    {
        
        curHP = Mathf.Clamp(curHP + amountToGive, 0, maxHP);
    }

    public void GiveAmmo(int amountToGive)
    {
        weapon.curAmmo = Mathf.Clamp(weapon.curAmmo + amountToGive, 0, weapon.maxAmmo);
    }
}