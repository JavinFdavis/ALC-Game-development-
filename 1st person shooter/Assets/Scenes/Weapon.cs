using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
    
    public ObjectPool bulletPool;
    public Transform muzzle;
    public int curAmmo;
    public int maxAmmo;
    public bool infiniteAmmo;
    public float bulletSpeed;
    public float shootRate;
    public float lastShootTime;
    public bool isPlayer;

    void Awake()  {
        //are we still attached to player
        if (GetComponent<PlayerController>()) {
            isPlayer = true;

        }
    }
//}
//{
    //can we shoot
    public bool CanShoot() {
         if(Time.time - lastShootTime >= shootRate){
        
    } 
    if (curAmmo > 0 || infiniteAmmo == true ) {
            return true; 
        }
        return false;
    }

    

//}
    //public void Shoot() {
       // lastShootTime = Time.time;
      //  curAmmo = curAmmo - 1;

        //GameObject bullet = Instantiate(bulletProjectile, muzzle.position, muzzle.rotation);

        //set volicity of bulletprojectile 
        //bullet.GetComponent<Rigidbody>().velocity = muzzle.forward;
    //}

    // Start is called before the first frame update
    public void Shoot() {
    lastShootTime = Time.time;
     //print(time.Time);
     curAmmo--;

     GameObject bullet = bulletPool.GetObject();
     bullet.transform. position = muzzle.position;
     bullet.transform.rotation = muzzle.rotation;

     // set the velocity 
     bullet.GetComponent<Rigidbody>(). velocity = muzzle.forward * bulletSpeed;
    }
}
