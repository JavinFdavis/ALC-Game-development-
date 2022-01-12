using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType 
{
    Health,
    Ammo
}

public class Pickup : MonoBehaviour
{

    public PickupType type; 

    public int ammoValue; 
    public int healthValue; 

    [Header ("Bobbing Anim")]
    public float rotationSpeed;
    public float bobSpeed;
    public float bobHeight;
    private Vector3 startPos;
    private bool bobbingUp;

    // Start is called before the first frame update
    void Start()
    {
        //setting start position 
        startPos = transform.position;

        healthValue = 25;
        ammoValue = 10;
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PlayerController playerController = other.GetComponent<PlayerController>();

            switch(type)
            {
                case PickupType.Health:
                    playerController.GiveHealth(healthValue);
                    break;
                case PickupType.Ammo:
                    playerController.GiveAmmo(ammoValue);
                     break;
            }

            Destroy (gameObject);
         }

    }


    void Update()
    {

    //rotating 
    transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);

    //Bob up and down
    Vector3 offset = (bobbingUp == true ? new Vector3(0,bobHeight / 2,0) : new Vector3(0, -bobHeight /2, 0));
    transform.position = Vector3.MoveTowards(transform.position, startPos + offset, bobSpeed * Time.deltaTime);

    if(transform.position == startPos + offset)
        bobbingUp = !bobbingUp;

    }
}