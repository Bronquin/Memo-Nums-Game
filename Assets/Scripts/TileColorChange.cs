using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileColorChange : MonoBehaviour {

    public Material[] materials;
    public Renderer Rend;

    // Use this for initialization
    void Start () {
        Rend = GetComponent<Renderer>();
        Rend.enabled = true;
        Rend.sharedMaterial = materials[0];
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag=="Player")
        {
            Rend.sharedMaterial = materials[1];
 //           Debug.Log("Enter");
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            Rend.sharedMaterial = materials[0];
 //           Debug.Log("Exit");
        }
    }
}
