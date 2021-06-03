using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float topBound = 30.0f;
    private float lowerBound = -10.0f;

    void Update()
    {
        if (transform.position.z > topBound)
        {
            gameObject.SetActive(false);
        } else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over");
            Destroy(gameObject);
        }
    }
}
