using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static OblakControls;

public class PickUpMedkit : MonoBehaviour
{
    public GameObject medkit, medkitInHands;
    public Rigidbody rigidMedkit;
    public BoxCollider collMedkit;
    public Transform medkitContainer, player;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;
    public bool equipped;
    public static bool slotFull;

    public void Start()
    {
        //medkitInHands.SetActive(false);
        if(!equipped)
        {
            medkitInHands.SetActive(false);
            rigidMedkit.isKinematic = false;
            collMedkit.isTrigger = false;
            slotFull = false;
        }

        if(equipped)
        {
            rigidMedkit.isKinematic = true;
            collMedkit.isTrigger = true;
            slotFull = true;
            medkitInHands.SetActive(true);
        }
    }


    public void Update()
    {
        
        //medkitInHands.SetActive(false);
        Vector3 distToPlayer = player.position - transform.position;
        if(!equipped && distToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.O) && !slotFull)
        PickUp();

        if(equipped && Input.GetKey(KeyCode.P))
        DropDown();
    }

    public void PickUp()
    {
        equipped = true;
        slotFull = true;
        medkit.SetActive(false);
        rigidMedkit.isKinematic = true;
        collMedkit.isTrigger = true;
        transform.SetParent(medkitContainer);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;
    }

    public void DropDown()
    {
        equipped = false;
        slotFull = false;
        
        rigidMedkit.isKinematic = false;
        collMedkit.isTrigger = false;
        transform.SetParent(null);
        rigidMedkit.velocity = player.GetComponent<Rigidbody>().velocity;
        // rigidMedkit.AddForce(dropForwardForce);
        

    }
}
