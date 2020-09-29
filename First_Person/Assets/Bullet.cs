using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float bulletLifetime;

    [SerializeField]
    int enemysLeft = 3;

    [SerializeField]
    int goToLevel = 0;

    float elapsed = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;

        if (elapsed >= bulletLifetime)
            Destroy(gameObject);


    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemysLeft = enemysLeft - 1;
            Debug.Log(enemysLeft);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        if (enemysLeft == 0)
        {
            SceneManager.LoadScene(goToLevel);
        }

    }
}
