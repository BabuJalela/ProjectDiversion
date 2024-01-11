using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float offsetx, offsetz;
    [SerializeField] private float movespeed;

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,new Vector3(target.position.x + offsetx,transform.position.y, target.position.z + offsetz), movespeed);
                   
    }

}
