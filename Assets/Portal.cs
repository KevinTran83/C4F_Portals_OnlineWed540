using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public Portal partner;

    public void Spawn(Vector3 spawnPos, Vector3 forward)
    {
        transform.position = spawnPos;
        transform.forward  = forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Teleportable")
        {
            other.transform.position = partner.transform.position + other.transform.forward * 2;
            other.transform.forward  = new Vector3(partner.transform.forward.x,
                                                   0,
                                                   partner.transform.forward.z).normalized;
        }
    }
}
