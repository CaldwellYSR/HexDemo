using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Hex currentHex;
    public float movementSpeed =10;

	void Start () {
        // Once the map is generated, establish the currentHex.
        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            // initializes currentHex with the child of the bottom leftmost hex on the grid.
            currentHex = GameObject.Find("Hex_0_0").GetComponent<Hex>();
        });

        // Listening for a hex to be clicked, taking the data passed with that event
        EventManager.Listen("Hex Clicked", (int x, int y) =>
        {
            //
            
            // finds the hex object at the given coordinates by creating the name from the coordinates
            GameObject selected = GameObject.Find("Hex_" + x + "_" + y);

            // if selected hex is a neighbor of the current hex
            if (currentHex.neighbors.Contains(selected) && selected.GetComponent<Hex>().walkable)
            {
                // set new current hex
                // Set the player to the center of that selected hex
                currentHex.GetComponent<Hex>().GetComponentInChildren<MeshRenderer>().material.color = Color.white;
                currentHex = selected.GetComponent<Hex>();
                Vector3 pos = selected.transform.position;
                this.transform.position = new Vector3(pos.x, pos.y + 0.25f, pos.z);
                selected.GetComponent<Hex>().GetComponentInChildren<MeshRenderer>().material.color = Color.red;
            }
        });
	}
    private void Update()
    {

    }
}
