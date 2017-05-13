using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x;
    public int y;
    public List<GameObject> neighbors;

    public void setupNeighbors()
    {
        // Left
        neighbors.Add(
            GameObject.Find("Hex_" + (x - 1) + "_" + y)
        );

        // Right
        neighbors.Add(
            GameObject.Find("Hex_" + (x + 1) + "_" + y)
        );

        if (y % 2 == 0)
        {
            // Down Left:       (1, 1)  (x - 1, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x - 1) + "_" + (y - 1))
            );
            // Down Right:      (2, 1)  (x, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y - 1))
            );
            // Up Left:         (1, 3)  (x - 1, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x - 1) + "_" + (y + 1))
            );
            // Up Right:        (2, 3)  (x, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y + 1))
            );
        }
        else
        {
            // Down Left:       (1, 0)  (x, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y - 1))
            );
            // Down Right:      (2, 0)  (x + 1, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x + 1) + "_" + (y - 1))
            );
            // Up Left:         (1, 2)  (x, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y + 1))
            );
            // Up Right:        (2, 2)  (x + 1, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x + 1) + "_" + (y + 1))
            );
        }

    }

}
