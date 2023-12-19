using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BurgerMan : MonoBehaviour
{

    [SerializeField] private Transform pickupTransform; //The location the items will be held, connected in inspector

    [SerializeField] private bool isHoldingItem = false; //OT calls this hasPickup

    [SerializeField] private bool hasAvailableItemInReach = false; //OT calls this isAvailableForPickup

    [SerializeField] private Transform currentItemAvailableForPickup; //Holds the immediately available pickupitem

    [SerializeField] private Transform currentItemBeingHeld = null;

    public UnityEvent OnItemPickUp;



    void Update()
    {
        if (hasAvailableItemInReach && !isHoldingItem)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("its picked up!");
                PickUpItem(currentItemAvailableForPickup);
            }
        }

        else if (isHoldingItem)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                DropItem(currentItemBeingHeld);
            }
        }
    }




    public void MakeItemAvailableForPickup(Transform itemToPickup)
    {
        Debug.Log("An item is within reach and can be picked up!");
        currentItemAvailableForPickup = itemToPickup;
        hasAvailableItemInReach = true;
    }

    public void MakeItemUnavailableForPickup()
    {
        Debug.Log("An item is no longer available to be picked up");
        currentItemAvailableForPickup = null;
        hasAvailableItemInReach = false;
    }






    public void PickUpItem(Transform itemToPickup)
    {
        //Set the position of the picked up item
        currentItemAvailableForPickup.position = pickupTransform.position;

        //Now hold it relative to the parent
        currentItemAvailableForPickup.SetParent(pickupTransform);

        //and set holding item to true
        isHoldingItem = true;

        //store the object being held
        currentItemBeingHeld = itemToPickup;

        //set off event
        OnItemPickUp.Invoke();

        Debug.Log("In theory, its picked up!");
    }


    public void DropItem(Transform itemBeingHeld)
    {
        //unchild it from parent to give it its own position again
        currentItemBeingHeld.SetParent(null);

        //set holding to false
        isHoldingItem = false;

        //remove this from the item being held value
        currentItemBeingHeld = null;
    }




    public bool IsHoldingItem()
    {
        return isHoldingItem;
    }


}
