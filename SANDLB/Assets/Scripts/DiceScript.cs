using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    [SerializeField] LayerMask DiceBox;

    Rigidbody rb;
    Vector3 defaultPosition;

    public int DiceValue
    {
        get;
        private set;
    } = 0;
    void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        defaultPosition = transform.position;
        DiceBox = ~DiceBox;
    }
    public void ThrowDice()
    {
        DiceValue = 0;
        transform.position = defaultPosition;

        float explosionForce = Random.Range(10, 50);
        Vector3 explosionPosition = transform.position + new Vector3(Random.Range(-30, 30), Random.Range(-10, 0), Random.Range(-30, 30));
        float upwardsModifier = Random.Range(10, 50);

        rb.AddExplosionForce(explosionForce, explosionPosition, 0, upwardsModifier, ForceMode.Impulse);

        StopAllCoroutines();
        StartCoroutine(DetectDiceStopping());
    }

    IEnumerator DetectDiceStopping()
    {
        Vector3 lastPosition = transform.position;
        do
        {
            lastPosition = transform.position;
            yield return new WaitForSeconds(0.3f);
        }
        while (lastPosition != transform.position);
        DiceValue = GetDiceValue();
        StopAllCoroutines();
    }

    int GetDiceValue()
    {
        RaycastHit hit;
        float maxHitDistance = -1;
        int maxFaceID = 0;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 3, ref maxFaceID);
        }
        if (Physics.Raycast(transform.position, -transform.forward, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 4, ref maxFaceID);
        }
        if (Physics.Raycast(transform.position, transform.right, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 1, ref maxFaceID);
        }
        if (Physics.Raycast(transform.position, -transform.right, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 6, ref maxFaceID);
        }
        if (Physics.Raycast(transform.position, transform.up, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 5, ref maxFaceID);
        }
        if (Physics.Raycast(transform.position, -transform.up, out hit, 100, DiceBox))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, 2, ref maxFaceID);
        }
        return maxFaceID;
    }
    float GetDiceFace(float dist1, float dist2, int faceID, ref int maxFaceID)
    {
        if (dist1 > dist2)
        {
            return dist1;
        }
        maxFaceID = faceID;
        return dist2;
    }
}
