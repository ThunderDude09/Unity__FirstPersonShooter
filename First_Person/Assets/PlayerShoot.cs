using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerShoot : MonoBehaviour
{
    public static PlayerShoot instance;
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform gunBarrel;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    //Image bar;
    public int ammo = 30;

    // Start is called before the first frame update
    void Start()
    {
        
        //UpdateHUD();

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetButtonDown("Fire1"))
        {
            
            ammo -= 1;

            //UpdateHUD();

            if (ammo > 0)
            {
                Vector3 bulletDirection = transform.forward * bulletSpeed;
                GameObject b = Instantiate(bullet, gunBarrel.position, gunBarrel.rotation);
                b.GetComponent<Rigidbody>().velocity = bulletDirection;
            }
        }
    }

    public void UpdateAmmo()
    {
        ammo = 30;
        //UpdateHUD();
    }

    /*void UpdateHUD()
    {
        //bar.fillAmount = (float)ammo / 30;
    }*/
}
