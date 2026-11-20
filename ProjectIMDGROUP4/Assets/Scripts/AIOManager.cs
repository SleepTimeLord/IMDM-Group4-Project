using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.Universal;

public class AIOManager : MonoBehaviour {
	public Camera camera;

	public GameObject CurrentDay;
	public GameObject SceneOne;
	public GameObject SceneTwo;
	public GameObject SceneThree;

	public GameObject ObjectOne;
	public GameObject ObjectTwo;
	public GameObject ObjectThree;

	private Vector3 PosOne;
	private Vector3 PosTwo;
	private Vector3 PosThree;

	private int changeFOV = 0;
	private float r;
	private float g;
	private float b;
	private float fov;

	// 0 = nothing held
	// 1 = whatever
	// 2 = whatever
	// 3 = whatever
	//public static int currentlyHeld = 0;

	public void drop() {
		CurrentDay.SetActive(true);

		SceneOne.SetActive(false);
		SceneTwo.SetActive(false);
		SceneThree.SetActive(false);

		ObjectOne.SetActive(true);
		ObjectTwo.SetActive(true);
		ObjectThree.SetActive(true);

		ObjectOne.transform.position = PosOne;
		ObjectTwo.transform.position = PosOne;
		ObjectThree.transform.position = PosOne;

		changeFOV = 1;
	}

	public void pickupOne() {
		Debug.Log("went to scene 1");
		CurrentDay.SetActive(false);
		SceneOne.SetActive(true);

		ObjectTwo.SetActive(false);
		ObjectThree.SetActive(false);
	}

	public void pickupTwo() {
		Debug.Log("went to scene 2");
		CurrentDay.SetActive(false);
		SceneTwo.SetActive(true);

		ObjectOne.SetActive(false);
		ObjectThree.SetActive(false);
	}

	public void pickupThree() {
		Debug.Log("went to scene 3");
		CurrentDay.SetActive(false);
		SceneThree.SetActive(true);

		ObjectOne.SetActive(false);
		ObjectTwo.SetActive(false);
	}

	void Start() {
		fov = camera.fieldOfView;
		PosOne = ObjectOne.transform.position;
		PosTwo = ObjectTwo.transform.position;
		PosThree = ObjectThree.transform.position;
		r = camera.GetComponent<Color>().r;
		g = camera.GetComponent<Color>().g;
		b = camera.GetComponent<Color>().b;
	}

	// Update is called once per frame
	void Update() {
		// if (Keyboard.current.spaceKey.wasPressedThisFrame) {
		// 	drop();
		// 	currentlyHeld = (currentlyHeld + 1) % 4;
		// }

		// if (currentlyHeld == 0 && !CurrentDay.activeSelf) {
		// 	drop();
		// }

		// if (currentlyHeld == 1 && !SceneOne.activeSelf) {
		// 	pickupOne();
		// }

		// if (currentlyHeld == 2 && !SceneOne.activeSelf) {
		// 	pickupTwo();
		// }

		// if (currentlyHeld == 3 && !SceneOne.activeSelf) {
		// 	pickupThree();
		// }

		if (changeFOV > 0) {
			changeFOV++;
			if (changeFOV > 512) {
				changeFOV = 0;
				camera.fieldOfView = fov;
			} else {
				camera.fieldOfView += 1;
			}
		}
	}
}