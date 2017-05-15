using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlacer : MonoBehaviour {
    public GameObject Player;
    public GameObject Hex;
    public int numberToplace;
	// Use this for initialization
	void Start () {
        numberToplace = 1;

        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            Hex[] hexes = GameObject.FindObjectsOfType<Hex>();
            for (int j = 0; j < numberToplace; j++)
            {
                Hex playerStart = HexUtility.GetHexByName("Hex_0_0");
                float playerX = playerStart.transform.position.x;
                float playerY = playerStart.transform.position.y + 0.25f;
                float playerZ = playerStart.transform.position.z;
                Vector3 playerPosition = new Vector3(playerX,playerY,playerZ);
                GameObject player = Instantiate(Player, playerPosition, Quaternion.identity);

            }

        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
