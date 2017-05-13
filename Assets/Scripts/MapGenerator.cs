using UnityEngine;

public class MapGenerator : MonoBehaviour {

    public GameObject Hex;

    int mapHeight = 20;
    int mapWidth = 20;

    float offsetX = 0.9f;
    float offsetZ = 0.78f;

    public void Start()
    {
        for (int x = 0; x < mapWidth; ++x)
        {
            for (int z = 0; z < mapHeight; ++z)
            {
                GameObject hex_go = Instantiate(Hex, calculatePosition(x, z), Quaternion.identity);

                // Setup parent and name
                hex_go.transform.parent = this.transform;
                hex_go.name = "Hex_" + x + "_" + z;
            }
        }
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
    }

    private Vector3 calculatePosition(int x, int z)
    {
        float xPos = x * offsetX;
        float zPos = z * offsetZ;

        if (z % 2 == 1)
        {
            xPos += offsetX * 0.5f;
        }

        return new Vector3(xPos, 0, zPos);
    }

}
