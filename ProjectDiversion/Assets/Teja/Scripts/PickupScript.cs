using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupScript : MonoBehaviour
{
    private GameObject PickedObj;
    public float throwforce;
    public float pickuprange = 10f;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P)) 
        {
            Trypickup();
        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Trythrow();
        }

       void Trypickup()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.forward, out hit, pickuprange)) 
            {
                if (hit.collider.CompareTag("Pickup"))
                {
                    PickedObj = hit.collider.gameObject;
                    PickedObj.transform.SetParent(transform);
                }
            }
        }

        void Trythrow()
        {
            if (PickedObj != null) 
            {
                PickedObj.transform.SetParent(null);
                Rigidbody rb = PickedObj.GetComponent<Rigidbody>();

                if (rb != null)
                {
                    rb.velocity = transform.forward * throwforce;
                }
                PickedObj = null;
            }
        }

   }







}

