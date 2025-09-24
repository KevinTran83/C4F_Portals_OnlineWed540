using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalSpawner : MonoBehaviour
{
    public Portal portalA, portalB;
    public LayerMask portalSurface;
    public ParticleSystem particles;

    private ParticleSystem.MainModule particlesMain;

    // Start is called before the first frame update
    void Start()
    {
        particlesMain = particles.main;


        portalA.gameObject.SetActive(false);
        portalB.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            particlesMain.startColor = new Color(0, 0, 1);
            particles.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if ( ( (1 << hit.collider.gameObject.layer) & portalSurface ) != 0)
                portalA.Spawn(hit.point, hit.normal);
                portalA.gameObject.SetActive(true);
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            particlesMain.startColor = new Color(1, 0.5f, 0);
            particles.Play();
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if ( ( (1 << hit.collider.gameObject.layer) & portalSurface ) != 0)
                portalB.Spawn(hit.point, hit.normal);
                portalB.gameObject.SetActive(true);
            }
        }
    }
}
