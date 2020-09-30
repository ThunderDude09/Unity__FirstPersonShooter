using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    int goToLevel = 0;

    [SerializeField]
    Image bar;
    public int ammo = 30;

    [SerializeField]
    Image bar2;
    int count = 3;

    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);
        UpdateHUD();
        UpdateHUD2();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            

            ammo -= 1;
            UpdateHUD();
            if (ammo > 0)
            {
                Vector3 bulletDirection = gunBarrel.forward * bulletSpeed;
                GameObject b = Instantiate(bullet, gunBarrel.position, transform.rotation);
                b.GetComponent<Rigidbody>().velocity = bulletDirection;
            }
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
        UpdateHUD2();
        if (count == 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(goToLevel);
        }
    }

    void UpdateHUD()
    {
        bar.fillAmount = (float)ammo / 30;
    }

    void UpdateHUD2()
    {
        bar2.fillAmount = (float)count / 3;
    }
}
