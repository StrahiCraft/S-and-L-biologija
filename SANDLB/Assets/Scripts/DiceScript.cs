using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    Rigidbody rb;
    Vector3 defaultPosition;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        defaultPosition = transform.position;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ThrowDice();
        }
    }
    public void ThrowDice()
    {
        transform.position = defaultPosition;

        float explosionForce = Random.Range(10, 50);
        Vector3 explosionPosition = transform.position + new Vector3(Random.Range(-30, 30), Random.Range(-10, 0), Random.Range(-30, 30));
        float upwardsModifier = Random.Range(10, 50);

        rb.AddExplosionForce(explosionForce, explosionPosition, 0, upwardsModifier, ForceMode.Impulse);
    }
}
