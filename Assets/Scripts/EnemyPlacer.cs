using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlacer : MonoBehaviour {
    public GameObject Enemy;
    public GameObject Hex;
    public int numberToPlace;
	// Use this for initialization
	void Start () {
        numberToPlace = 3;
        //get all of the hexes that aren't start, and are walkable
        

        EventManager.Listen("Map Generated", (int x, int y) =>
        {
            print("Map generated, placing enemies");
            Hex[] hexes = GameObject.FindObjectsOfType<Hex>();
            print(hexes.Length);
            for (int j = 0; j < numberToPlace; j++)
            {
                Hex[] filteredHexes = HexUtility.FilterWalkable(hexes);
                Hex randomHex = filteredHexes[Random.Range(0, filteredHexes.Length)];
                print(filteredHexes.Length);
                float enemyX = randomHex.transform.position.x;
                float enemyY = randomHex.transform.position.y + 0.25f;
                float enemyZ = randomHex.transform.position.z;
                Vector3 enemyPosition = new Vector3(enemyX, enemyY, enemyZ);
                GameObject enemy = Instantiate(Enemy, enemyPosition, Quaternion.identity);
                enemy.transform.parent = this.transform;
                enemy.name = "Enemy_" + j;
                randomHex.occupied = true;
                //TODO: Make sure enemies don't land on same hex as other enemies, or the player
            }
        });
	}

	// Update is called once per frame
	void Update () {
		
	}
}
