﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField]
    Transform[] targets;
    int targetIndex = 0;
    Transform currentTarget;

    [SerializeField]
    float speed = 0;

    [SerializeField]
    float dist = 0;

    // Start is called before the first frame update
    void Start()
    {
        UpdateTarget();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentTarget.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentTarget.position) < dist)
        {
            targetIndex++;
            if (targetIndex >= targets.Length)
                targetIndex = 0;

            UpdateTarget();
        }
    }

    void UpdateTarget()
    {
        currentTarget = targets[targetIndex];
    }
}
