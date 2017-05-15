using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    private Hex currentHex;
    private Vector3 targetPosition;
    private bool initialPositionSet;
    public float speed = 10f;

	void Start () {
        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            // initializes currentHex with the child of the bottom leftmost hex on the grid.
            currentHex = GameObject.Find("Hex_2_1").GetComponent<Hex>();
            this.transform.position = currentHex.transform.position;
            targetPosition = this.transform.position;
            initialPositionSet = true;
            currentHex.GetComponent<Hex>().GetComponentInChildren<MeshRenderer>().material.color = Color.blue;
        });

      
	}
    public void Update()
    {

        // If target position has changed we need to incrimentally move towards
        // the new target position
        if (targetPosition != this.transform.position && initialPositionSet)
        {
            this.transform.position = Vector3.Lerp(this.transform.position, targetPosition, Time.deltaTime * speed);
        }
        
    }
}
