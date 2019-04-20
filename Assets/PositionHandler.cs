using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionHandler : MonoBehaviour
{
	
	public int count;
	public bool isFocus = false;

	// Start is called before the first frame update
	void Start()
    {
		Debug.Log("Starting Coroutine");
		StartCoroutine(LoadFromLikeCoroutine()); // execute this section independently

	}

	// Update is called once per frame
	void Update()
    {
		if (Camera.main.GetComponent<RayCast>().whoCount != this.count)
		{
			this.isFocus = false;
			//this.GetComponent<BoxCollider>().enabled = true;
		}

		transform.LookAt(Camera.main.transform);

		Vector3 baseDir = 10 * new Vector3(Mathf.Cos((Mathf.PI / 15) * (count % 30)),
										   0,
										   Mathf.Sin((Mathf.PI / 15) * (count % 30)));
		Vector3 angledDir = baseDir + new Vector3(0, (count/30), 0);

		Vector3 normalizedDir = Vector3.Normalize(angledDir);

		Vector3 finalDir = normalizedDir * 10;

		Vector3 onlyXZ = new Vector3(finalDir.x, 0, finalDir.z);

		float newRadius = onlyXZ.magnitude;

		if (!this.isFocus)
		{
			transform.position = Camera.main.transform.position + finalDir;
		}
		else
		{
			transform.position = Camera.main.transform.position + Vector3.Normalize(onlyXZ) * 2;
			//this.GetComponent<BoxCollider>().enabled = false;
		}

	}

	private IEnumerator LoadFromLikeCoroutine()
	{
		Debug.Log("Inside Coroutine");
		int counter = 0;
		//string pathL = @"C:\Users\bardi\Desktop\Links.txt";
		string pathL = @".\Assets\Links.txt";
		string line;
		System.IO.StreamReader file = new System.IO.StreamReader(pathL);

		while ((line = file.ReadLine()) != null)
		{
			counter++;
			if (counter == count)
			{
				Debug.Log("Found correct link");
				WWW wwwLoader = new WWW(line);
				yield return wwwLoader;
				this.GetComponent<Renderer>().material.mainTexture = wwwLoader.texture;
				break;
			}
		}
		file.Close();
		
	}

}
