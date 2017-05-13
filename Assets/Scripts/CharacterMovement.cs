using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

    public Hex currentHex;

	void Start () {
        EventManager.Listen("Hex Clicked", (int x, int y) =>
        {
            Debug.Log("Clicked a hex: (" + x + ", " + y + ")");
        });
	}
}
