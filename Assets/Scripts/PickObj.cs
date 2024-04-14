using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObj : MonoBehaviour
{
    public GameObject Item;
    public Transform ItemParent, player;

    public float pickUpRange;

    public float throwObject;
    public float rotSpeed;

    public bool equipped;
    Vector3 distToObject, currentEulerAngles;
    void Start()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        distToObject = player.position - transform.position;
        
        if(Input.GetKey(KeyCode.M) && distToObject.magnitude <= pickUpRange && !equipped)
        {
            PickUpFunc();
        }

        if(Input.GetKey(KeyCode.N) && equipped)
        {
            DropDownFunc();
        }
    }
    public void PickUpFunc()
    {
        Item.GetComponent<Rigidbody>().isKinematic = true;

        Item.transform.position = ItemParent.transform.position;
        Item.transform.rotation = ItemParent.transform.rotation;

        Item.GetComponent<MeshCollider>().enabled = false;

        Item.transform.SetParent(ItemParent);
        equipped = true;
        print("Equipped!");
        

    }
    public void DropDownFunc()
    {
        ItemParent.DetachChildren();
        currentEulerAngles += new Vector3(Item.transform.position.x, Item.transform.position.y, Item.transform.position.z) * rotSpeed;
        transform.eulerAngles = currentEulerAngles;
        Item.GetComponent<Rigidbody>().isKinematic = false;
        Item.GetComponent<Rigidbody>().AddForce(transform.forward * throwObject);
        Item.GetComponent<MeshCollider>().enabled = true;
        equipped = false;
        
        print("Not equipped..");
    }
}
