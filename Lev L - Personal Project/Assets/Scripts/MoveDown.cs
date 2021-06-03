using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDown : MonoBehaviour
{
    [SerializeField] private float speed = 20;
    private Rigidbody objectRb;
    private float bottomBound = -10;

    void Start()
    {
        objectRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MoveEnemyDown();
        DestroyOutOfBounds();
    }

    void MoveEnemyDown()
    {
        objectRb.AddForce(-Vector3.forward * speed);
    }

    void DestroyOutOfBounds()
    {
        if (transform.position.z < bottomBound)
        {
            Destroy(gameObject);
        }
    }
}
