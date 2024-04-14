using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpObj : MonoBehaviour
{
    public GameObject bonusInHands;
    public GameObject pickUpText;
    public bool equipped;

    void Start()
    {
        bonusInHands.SetActive(false);
        pickUpText.SetActive(false);
        equipped = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            pickUpText.SetActive(true);
            if(Input.GetKey(KeyCode.T))
            {
                this.gameObject.SetActive(false);
                bonusInHands.SetActive(true);
                equipped = true;
                print("Equipped");
                pickUpText.SetActive(false);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        pickUpText.SetActive(false);
        
        if(other.gameObject.tag == "Player")
        {
            if(Input.GetKey(KeyCode.Y))
            {
                this.gameObject.SetActive(true);
                bonusInHands.SetActive(false);
                equipped = false;
                print("Dropped it");
            }
        }
        
    }

}
