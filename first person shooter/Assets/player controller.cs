using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

void Awake()  {
    //get components 
    cam = Camera.main;
    rb = GetComponent<Rigidbody>();
}

// update is called once per frame
void Update (){
    move();
    camlook;
}
void Move()  {
    float x = Input.GetAxis("Horizontal") * moveSpeed;
    float z = Input GetAxis("Vertical") * moveSpeed;
}

Vector3 dir = transform.right * x + transform.foward  * z;
dir = rb.velocity.y;
}