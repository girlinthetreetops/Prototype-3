using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupManager : MonoBehaviour
{

    private BurgerMan burgerMan;

    void Start()
    {
        burgerMan = GetComponentInParent<BurgerMan>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("A collision is detected....");

        if (other.CompareTag("BurgerComponent"))
        {
            if (burgerMan.IsHoldingItem()) { return; } //add error sound for already holding stuff

            Debug.Log("And its a BURGER COMPONENT! So make it available for pickup!");
            burgerMan.MakeItemAvailableForPickup(other.transform);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Youve left an item...");

        if (other.CompareTag("BurgerComponent"))
        {
            Debug.Log("And because this item is a burger component, I'd like to make it unavailable");
            burgerMan.MakeItemUnavailableForPickup();
                
        }
    }
}
