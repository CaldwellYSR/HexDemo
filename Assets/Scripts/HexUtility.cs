using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexUtility : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static Hex[] FilterWalkable(Hex[] input)
    {
        List<Hex> availableHex = new List<Hex>();
        foreach (Hex h in input)
        {
            if (h.walkable && !h.occupied)
            {
                availableHex.Add(h);
            }
        }
        return availableHex.ToArray();

    }
    public static Hex GetHexByName(string input)
    {
        return GameObject.Find(input).GetComponent<Hex>();
    }
}
