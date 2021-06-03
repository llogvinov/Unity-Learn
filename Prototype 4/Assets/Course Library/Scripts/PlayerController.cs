using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameObject focalPoint;
    public GameObject powerUpIndicator;
    private float speed = 5;
    private float powerUpStrength = 15;
    private bool hasPowerUp = false;

    void Start() {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("FocalPoint");
    }

    void Update() {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        powerUpIndicator.transform.position = transform.position + new Vector3(0, -0.5f, 0);
    }

    IEnumerator PowerUpCountdownRoutine() {
        yield return new WaitForSeconds(5);
        hasPowerUp = false;
        powerUpIndicator.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("PowerUp")) {
            StartCoroutine(PowerUpCountdownRoutine());
            Destroy(other.gameObject);
            hasPowerUp = true;
            powerUpIndicator.gameObject.SetActive(true);
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Enemy") & hasPowerUp) {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

            enemyRb.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        }
    }
}
