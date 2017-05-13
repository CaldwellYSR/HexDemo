using System.Collections.Generic;
using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public Material highlight;

    public void Update()
    {
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo))
        {
            Transform selected = hitInfo.collider.gameObject.transform.parent;
            if (Input.GetMouseButtonUp(0))
            {
                Hex hex = selected.GetComponent<Hex>();
                EventManager.Broadcast("Hex Clicked", hex.x, hex.y);
            }
        }
    }

}
