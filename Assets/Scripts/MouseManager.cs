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
                List<GameObject> neighbors = selected.GetComponent<Hex>().neighbors;
                for (int i = 0; i < neighbors.Count; ++i)
                {
                    if (neighbors[i].GetComponentInChildren<MeshRenderer>().material.color == Color.red)
                    {
                        neighbors[i].GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                    }
                    else
                    {
                        neighbors[i].GetComponentInChildren<MeshRenderer>().material.color = Color.red;
                    }
                }
            }
        }
    }

}
