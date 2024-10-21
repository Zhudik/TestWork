using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private Camera characterCamera;

    [SerializeField]
    private Transform slot;
    private Item pickedItem;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (pickedItem)
            {
                DropItem(pickedItem);
            }
            else
            {
          
                Ray ray = characterCamera.ViewportPointToRay(Vector3.one * 0.5f);
                RaycastHit hit;
        
                if (Physics.Raycast(ray, out hit, 1.5f))
                {

                    Item pickable = hit.transform.GetComponent<Item>();
        
                    if (pickable)
                    {
     
                        PickItem(pickable);
                    }
                }
            }
        }
    }

    private void PickItem(Item item)
    {
        pickedItem = item;

        item.Rb.isKinematic = true;
        item.Rb.velocity = Vector3.zero;
        item.Rb.angularVelocity = Vector3.zero;
        item.transform.SetParent(slot);
        item.transform.localPosition = Vector3.zero;
        item.transform.localEulerAngles = Vector3.zero;
    }
    private void DropItem(Item item)
    {
        pickedItem = null;
        item.transform.SetParent(null);
        item.Rb.isKinematic = false;
        item.Rb.AddForce(item.transform.forward * 2, ForceMode.VelocityChange);
    }
}
