using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
        public int damage;
        public float lifeTime;
        private float shootTime;

        public GameObject hitParticle;


        // Start is called before the first frame update
        void Start()
        {
            
        }
    void OnEnable()
    {
        shootTime = Time.time; 
    }
    void OnTriggerEnter(Collider other)
    {
        // create particle effect on hit then destroy particle effect
        GameObject obj = Instantiate(hitParticle, transform.position, Quaternion.identity);
        Destroy(obj, 1.0f);



     //did we hit the player
     if(other.CompareTag("Player"))
        other.GetComponent<PlayerController>().TakeDamage(damage);
        else if(other.CompareTag("Enemy"))
        other.GetComponent<Enemy>().TakeDamage(damage);

        //Disable the bullet
        gameObject.SetActive(false);

        
    }
    // Update is called once per frame
    void Update()
     {
        if(Time.time - shootTime >= lifeTime)
        gameObject.SetActive(false);
    }
}
