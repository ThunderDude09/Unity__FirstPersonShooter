using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy2 : MonoBehaviour
{
    [SerializeField]
    Transform target;

    [SerializeField]
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, speed * Time.deltaTime);
    }
}
