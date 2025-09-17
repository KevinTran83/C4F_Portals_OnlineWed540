using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public Portal portalA, portalB;
    public LayerMask portalSurface;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if ( ( (1 << hit.collider.gameObject.layer) & portalSurface ) != 0)
                portalA.Spawn(hit.point, hit.normal);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if ( ( (1 << hit.collider.gameObject.layer) & portalSurface ) != 0)
                portalB.Spawn(hit.point, hit.normal);
            }
        }
    }
}
