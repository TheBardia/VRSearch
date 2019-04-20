using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;

public class FrameSpawner : MonoBehaviour
{

	GameObject[] allFrames;
	public int totalCount;
	public GameObject pref;

	// Start is called before the first frame update
	void Start()
    {

		allFrames = new GameObject[totalCount];

		for (int counter = 0; counter < totalCount; counter++)
		{
			allFrames[counter] = Instantiate(pref, transform.position, transform.rotation);
			allFrames[counter].GetComponent<PositionHandler>().count = counter;
		}

	}



		// Update is called once per frame
		void Update()
    {
        
    }
}
