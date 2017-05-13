using System.Collections.Generic;
using UnityEngine;

public class Hex : MonoBehaviour {

    public int x;
    public int y;
    public List<GameObject> neighbors;

    // Create the neighbors. The math for "down left" and such are 
    // kind of magic but they're above each neighbors.add call
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
            // Down Left:       (x - 1, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x - 1) + "_" + (y - 1))
            );
            // Down Right:      (x, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y - 1))
            );
            // Up Left:         (x - 1, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x - 1) + "_" + (y + 1))
            );
            // Up Right:        (x, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y + 1))
            );
        }
        else
        {
            // Down Left:       (x, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y - 1))
            );
            // Down Right:      (x + 1, y - 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x + 1) + "_" + (y - 1))
            );
            // Up Left:         (x, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + x + "_" + (y + 1))
            );
            // Up Right:        (x + 1, y + 1)
            neighbors.Add(
                GameObject.Find("Hex_" + (x + 1) + "_" + (y + 1))
            );
        }

    }

}
