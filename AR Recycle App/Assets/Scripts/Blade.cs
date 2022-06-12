using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.ARFoundation;

public class Blade : MonoBehaviour
{

	public GameObject bladeTrailPrefab;
	public float minCuttingVelocity = .001f;

	bool isCutting = false;

	Vector2 previousPosition;

	GameObject currentBladeTrail;

	Rigidbody2D rb;
	Camera cam;
	CircleCollider2D circleCollider;

	void Start()
	{
		cam = FindObjectOfType<ARSessionOrigin>().camera;
		rb = GetComponent<Rigidbody2D>();
		circleCollider = GetComponent<CircleCollider2D>();
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.touchCount > 0)
		{
			StartCutting();
		}
		else if (Input.touchCount <= 0)
		{
			StopCutting();
		}

		if (isCutting)
		{
			UpdateCut();
		}

	}

	void UpdateCut()
	{
		Vector2 newPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
		rb.position = newPosition;

		float velocity = (newPosition - previousPosition).magnitude * Time.deltaTime;
		if (velocity > minCuttingVelocity)
		{
			circleCollider.enabled = true;
		}
		else
		{
			circleCollider.enabled = false;
		}

		previousPosition = newPosition;
	}

	void StartCutting()
	{
		isCutting = true;
		currentBladeTrail = Instantiate(bladeTrailPrefab, transform);
		previousPosition = cam.ScreenToWorldPoint(Input.GetTouch(0).position);
		circleCollider.enabled = false;
	}

	void StopCutting()
	{
		isCutting = false;
		currentBladeTrail.transform.SetParent(null);
		Destroy(currentBladeTrail, 2f);
		circleCollider.enabled = false;
	}

}
