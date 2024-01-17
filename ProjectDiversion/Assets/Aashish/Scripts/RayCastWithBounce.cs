using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWithBounce : MonoBehaviour
{
    [SerializeField] private float MaxDistance = 100f;
    [SerializeField] private int Bounces = 5;

    public LayerMask layerMask;

    void FixedUpdate()
    {
        List<RaycastHit> hits = new List<RaycastHit>();

        RaycastWithBounces(new Ray(transform.position, transform.forward), ref hits, MaxDistance, layerMask, Bounces);

        List<Vector3> points = new List<Vector3>();

        points.Add(transform.position);

        foreach (var hit in hits)
        {
            points.Add(hit.point);
        }

        Vector3 finalPoint = (points[^1] + transform.forward) * 100f;

        if (hits.Count > 0)
        {
            finalPoint = points[^1] + (Vector3.Reflect((points[^1] - points[^2]).normalized, hits[^1].normal) * 100f);
        }

        points.Add(finalPoint);

        for (int i = 0; i < points.Count - 1; i++)
        {
            Debug.DrawLine(points[i], points[i + 1], Color.red);
        }
    }

    public void RaycastWithBounces(Ray ray, ref List<RaycastHit> hitInfos, float maxDistance, int layerMask, int bounces)
    {
        int currentBounces = 0;
        Ray currentRay = ray;
        RaycastHit currentHitInfo = new RaycastHit();
        hitInfos = new List<RaycastHit>();

        while (currentBounces < bounces && Physics.Raycast(currentRay, out currentHitInfo, maxDistance, layerMask))
        {
            if(currentHitInfo.collider != null)
            {
                currentBounces++;
                currentRay.origin = currentHitInfo.point;
                currentRay.direction = Vector3.Reflect(currentRay.direction, currentHitInfo.normal);
            }
            else
            {
                break;
            }

            hitInfos.Add(currentHitInfo);
        }
    }
}