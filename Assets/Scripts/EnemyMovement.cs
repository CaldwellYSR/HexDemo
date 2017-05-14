using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Hex currentHex;
    private Vector3 targetPosition;
    public float speed = 10f;

	void Start () {

        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            // initializes currentHex with the child of the bottom leftmost hex on the grid.
            currentHex = GameObject.Find("Hex_2_1").GetComponent<Hex>();
            Vector3 pos = currentHex.transform.position;
            this.transform.position = new Vector3(pos.x, pos.y + 0.25f, pos.z);
            targetPosition = this.transform.position;
            currentHex.GetComponent<Hex>().GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
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

                // Set target position to the selected hex's position
                currentHex = selected.GetComponent<Hex>();
                Vector3 pos = selected.transform.position;
                targetPosition = new Vector3(pos.x, pos.y + 0.25f, pos.z);

                selected.GetComponent<Hex>().GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
            }
        });
	}
    public void Update()
    {

        // If target position has changed we need to incrimentally move towards
        // the new target position
        if (targetPosition != this.transform.position)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * speed);
        }

    }
}
