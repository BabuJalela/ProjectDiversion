using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    [SerializeField] private Transform playercameratransform;
    [SerializeField] private LayerMask pickuplayermasl;
    [SerializeField] private Transform objectgrabpointtransform;

    private Picables pickables;

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.E))
        {
            if (pickables == null)
            {



                float pickupidis = 2f;

                if (Physics.Raycast(playercameratransform.transform.position, playercameratransform.forward, out RaycastHit raycasthit, pickupidis, pickuplayermasl))
                {
                    Debug.Log(raycasthit.transform);

                    if (raycasthit.transform.TryGetComponent(out pickables))
                    {
                        pickables.Grab(objectgrabpointtransform);
                        Debug.Log(pickables);
                    }
                }

            } else
            {
                pickables.drop();
                pickables = null;
            }
                

                
             

            
        }
    }
    //public Camera cam;

    //private void Start()
    //{
    //    //cam = Camera.main;
    //    print(cam.name);
    //}

    //private void Update()
    //{
    //    Vector3 mouseposition = Input.mousePosition;
    //    mouseposition.z = 10f;
    //    mouseposition = cam.ScreenToWorldPoint(mouseposition);
    //    Debug.DrawRay(transform.position, mouseposition - transform.position, Color.blue);

    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
    //        RaycastHit hit;

    //        if (Physics.Raycast(ray, out hit, 100))
    //        {
    //            Debug.Log(hit.transform.name);
    //        }
    //    }
    //}

}

