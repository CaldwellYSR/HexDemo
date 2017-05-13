using UnityEngine;

public class MapGenerator : MonoBehaviour {

    // Prefab used to build hex grid
    public GameObject Hex;

    // Number of hexes wide and tall the map is
    // This is not the world space
    int mapHeight = 20;
    int mapWidth = 20;

    // How much space in world units to move each individual hex
    float offsetX = 0.9f;
    float offsetZ = 0.78f;

    public void Start()
    {

        // Set up the map hexes with prefabs
        for (int x = 0; x < mapWidth; ++x)
        {
            for (int z = 0; z < mapHeight; ++z)
            {
                GameObject hex_go = Instantiate(Hex, calculatePosition(x, z), Quaternion.identity);

                // Setup parent and name
                // Setting parent to empty map object for
                // a cleaner hierarchy
                hex_go.transform.parent = this.transform;
                hex_go.name = "Hex_" + x + "_" + z;
            }
        }

        // Loop through again to set up the hex coordinate system and neighbors
        for (int x = 0; x < mapWidth; ++x)
        {
            for (int z = 0; z < mapHeight; ++z)
            {
                GameObject hex_go = GameObject.Find("Hex_" + x + "_" + z);
                // Set up coordinate system so we can find neighbors
                Hex hex = hex_go.GetComponent<Hex>();
                hex.x = x;
                hex.y = z;
                hex.setupNeighbors();
            }
        }

        // Let anyone who cares know that we have finished generating
        // The map. Passing -1s for now... will probably change
        // TODO: Determine if event manager needs to be changed
        EventManager.Broadcast("Map Generated", -1, -1);
    }

    // Helper function for getting position of current hex based on
    // it's internal coordinate system
    private Vector3 calculatePosition(int x, int z)
    {
        float xPos = x * offsetX;
        float zPos = z * offsetZ;

        // Because it is hexes every odd row needs to increment by
        // half fof the x Offset. This is what makes them overlap correctly
        if (z % 2 == 1)
        {
            xPos += offsetX * 0.5f;
        }

        return new Vector3(xPos, 0, zPos);
    }

}
