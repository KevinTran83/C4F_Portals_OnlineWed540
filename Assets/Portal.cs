using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public void Spawn(Vector3 spawnPos, Vector3 forward)
    {
        transform.position = spawnPos;
        transform.forward  = forward;
    }
}
