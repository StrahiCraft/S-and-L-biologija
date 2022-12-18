using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour
{
    [SerializeField] LayerMask DiceBoxLayer;

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
        DiceBoxLayer = ~DiceBoxLayer;
    }
    public void ThrowDice()
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManagerScript>().Play("DiceRoll");

        DiceValue = 0;
        transform.position = defaultPosition;

        float explosionForce = Random.Range(100, 500);
        Vector3 explosionPosition = transform.position + new Vector3(Random.Range(-30, 30), Random.Range(-10, 0), Random.Range(-30, 30));
        float upwardsModifier = Random.Range(100, 500);

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
        float maxHitDistance = -1;
        int maxFaceID = 0;
        DoDiceFaceRaycast(transform.right, 1, ref maxHitDistance, ref maxFaceID);
        DoDiceFaceRaycast(-transform.up, 2, ref maxHitDistance, ref maxFaceID);
        DoDiceFaceRaycast(transform.forward, 3, ref maxHitDistance, ref maxFaceID);
        DoDiceFaceRaycast(-transform.forward, 4, ref maxHitDistance, ref maxFaceID);
        DoDiceFaceRaycast(transform.up, 5, ref maxHitDistance, ref maxFaceID);
        DoDiceFaceRaycast(-transform.right, 6, ref maxHitDistance, ref maxFaceID);
        return maxFaceID;
    }
    void DoDiceFaceRaycast(Vector3 direction, int diceFaceNumber, ref float maxHitDistance, ref int maxFaceID)
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position,direction , out hit, 100, DiceBoxLayer))
        {
            maxHitDistance = GetDiceFace(maxHitDistance, hit.distance, diceFaceNumber, ref maxFaceID);
        }
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
