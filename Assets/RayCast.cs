using UnityEngine;
using System.Collections;

public class RayCast : MonoBehaviour
{
	public Camera camera;
	public GameObject whoHit;
	public int whoCount;
	public int whoCountOld;
	
	void Update()
	{
		whoCountOld = whoCount;
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hit;
			Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5F, 0.5F, 0));

			if (Physics.Raycast(ray, out hit))
			{
				Debug.Log("Hit");
				hit.collider.gameObject.GetComponent<PositionHandler>().isFocus = true;
				whoCount = hit.collider.gameObject.GetComponent<PositionHandler>().count;
			}
			if(whoCount == whoCountOld)
			{
				hit.collider.gameObject.GetComponent<PositionHandler>().isFocus = false;
			}
		}
	}
}