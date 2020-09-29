using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    GameObject bullet;

    [SerializeField]
    Transform gunBarrel;

    [SerializeField]
    float bulletSpeed;

    [SerializeField]
    int goToLevel = 0;

    [SerializeField]
    //Image bar;
    public int ammo = 30;

    [SerializeField]
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        UpdateHUD();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Vector3 bulletDirection = transform.forward * bulletSpeed;
            GameObject b = Instantiate(bullet, gunBarrel.position, transform.rotation);
            b.GetComponent<Rigidbody>().velocity = bulletDirection;
        }
    }

    public void UpdateAmmo()
    {
        ammo = 30;
        UpdateHUD();
    }

    public void UpdateEnemy()
    {
        count = count - 1;
        Debug.Log(count);
        if (count == 0)
        {
            SceneManager.LoadScene(goToLevel);
        }
    }

    void UpdateHUD()
    {
        //bar.fillAmount = (float)ammo / 30;
    }
}
