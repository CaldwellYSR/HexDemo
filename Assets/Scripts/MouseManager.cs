using UnityEngine;

public class MouseManager : MonoBehaviour
{

    public Material highlight;

    public void Update()
    {

        // Cast a ray to see if we are clicking on anything
        // Currently only used for hexes but this file should
        // be used as a dispatcher to send all "mouse events" 
        // to objects that might care about the mouse
        Ray mouseRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;

        if (Physics.Raycast(mouseRay, out hitInfo))
        {

            // Get the selected hex and tell people it has been clicked
            Transform selected = hitInfo.collider.gameObject.transform.parent;
            if (Input.GetMouseButtonUp(0))
            {
                Hex hex = selected.GetComponent<Hex>();
                EventManager.Broadcast("Hex Clicked", hex.x, hex.y);
            }
        }
    }

}
