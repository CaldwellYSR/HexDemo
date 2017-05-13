using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    private Hex currentHex;

	void Start () {
        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            currentHex = GameObject.Find("Hex_0_0").GetComponent<Hex>();
        });
        EventManager.Listen("Hex Clicked", (int x, int y) =>
        {
            GameObject selected = GameObject.Find("Hex_" + x + "_" + y);
            if (currentHex.neighbors.Contains(selected))
            {
                currentHex = selected.GetComponent<Hex>();
                Vector3 pos = selected.transform.position;
                this.transform.position = new Vector3(pos.x, pos.y + 0.25f, pos.z);
            }
        });
	}
}
