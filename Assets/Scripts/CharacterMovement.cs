using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Hex currentHex;
    private Vector3 targetPosition;
    public float speed = 10f;

	void Start () {

        targetPosition = this.transform.position;

        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            // initializes currentHex with the child of the bottom leftmost hex on the grid.
            currentHex = GameObject.Find("Hex_0_0").GetComponent<Hex>();
            currentHex.GetComponent<Hex>().targetColor = Color.red;
        });

        // Listening for a hex to be clicked, taking the data passed with that event
        EventManager.Listen("Hex Clicked", (int x, int y) =>
        {

            // finds the hex object at the given coordinates by creating the name from the coordinates
            GameObject selected = GameObject.Find("Hex_" + x + "_" + y);

            AStarPathFinder aStar = new AStarPathFinder(this.currentHex, selected.GetComponent<Hex>());

            Debug.Log(aStar.hexHScore(this.currentHex));

            /*
            // if selected hex is a neighbor of the current hex
            if (currentHex.neighbors.Contains(selected) && selected.GetComponent<Hex>().walkable)
            {
                // set new current hex
                // Set the player to the center of that selected hex
                currentHex.GetComponent<Hex>().targetColor = Color.white;

                // Set target position to the selected hex's position
                currentHex = selected.GetComponent<Hex>();
                Vector3 pos = selected.transform.position;
                targetPosition = new Vector3(pos.x, pos.y + 0.25f, pos.z);

                selected.GetComponent<Hex>().targetColor = Color.red;
            }
            */
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
