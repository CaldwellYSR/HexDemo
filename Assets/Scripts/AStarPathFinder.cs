using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class AStarPathFinder {

    // Open list is used for available hex's to move into
    // Closed list is "selected" tiles used to build a path
    // from the currentHex to the target Hex
    private List<Hex> open = new List<Hex>();
    private List<Hex> closed = new List<Hex>();
    private Hex currentHex;
    private Hex targetHex;

    public AStarPathFinder(Hex currentHex, Hex targetHex)
    {
        // Add current hex to the open list and start pathfinding from there
        this.currentHex = currentHex;
        this.targetHex = targetHex;
        open.Add(currentHex);
    }

    public List<Hex> getPath()
    {
        while (!open.Contains(targetHex))
        {
            this.findPath();
        }
        closed.Remove(currentHex);
        closed.Add(targetHex);
        return closed;
    }

    private void findPath()
    {
        // Take the first hex out of the open list and move to closed
        // Since we will sort the list by F Score the first hex
        // in the list should be the "ideal" path
        Hex hex = open[0];
        open.RemoveAt(0);
        closed.Add(hex);

        // Loop through neighbors and all all walkable hexes to the open list
        foreach (GameObject go in hex.neighbors)
        {
            if (go == null)
            {
                continue;
            }
            Hex h = go.GetComponent<Hex>();
            if (closed.Contains(h))
            {
                continue;
            }
            if (h.walkable)
            {
                h.parent = hex; 
                open.Add(h);
            }
        }

        // Sort the newly updated open list by F score
        open = sortList();
    }

    // Sort the list by f score
    private List<Hex> sortList()
    {
        return open.OrderBy(hex => this.hexFScore(hex)).ToList();
    }

    // F Score is just the G score plus the H score
    private int hexFScore(Hex hex)
    {
        return hexGScore(hex) + hexHScore(hex);
    }

    // TODO: Determine if G score is always 1 or not
    //
    // G Score will usually be 1 since moving from the center of 1 hex to
    // the center of the next hex is just one unit regardless of direction
    // If we were using squares instead of hexes this would need some more 
    // math to handle diagonal movement being a longer distance to travel
    private int hexGScore(Hex hex)
    {
        return 1;
    }

    // H Score is the "block distance" from the hex in question to the
    // target hex of the path. This will ignore walkability of the tiles
    public int hexHScore(Hex hex)
    {
        return Mathf.Abs(targetHex.x - hex.x) + Mathf.Abs(targetHex.y - hex.y);
    }

}
