using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.LookDev;

public class AIOManager : MonoBehaviour {
	public Camera camera;
	public Volume globalVolume;
	public GameObject[] itemList;
	[Header("Main Scene")]
	public GameObject mainScene;
	public VolumeProfile mainVp;
	public Material mainSkybox;

	[SerializeField]
	private GameObject currentScene;

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

	void Start() {
		itemList = GameObject.FindGameObjectsWithTag("Interactable");
		currentScene = mainScene;

		fov = camera.fieldOfView;
		r = camera.GetComponent<Color>().r;
		g = camera.GetComponent<Color>().g;
		b = camera.GetComponent<Color>().b;
	}

	/// <summary>
	/// basically change to this specific items scene and do whatever is done when pickup item
	/// makes it so we can just change this one script and I dont have to keep copy and pasting
	/// </summary>
	public void Pickup(GameObject scene, GameObject itemGrabbing, VolumeProfile vp, Material skybox)
	{
		// hides the rest of the items except for the chosen item
		foreach(GameObject item in itemList)
		{
			if (item == itemGrabbing) continue;
			item.SetActive(false);
		}

		// change to scene connected to the item player is grabbing
		SceneTransition(vp, scene, skybox);
	}

	/// <summary>
	/// when drop item go back to the main scene and do whatever. Gets called in 
	/// TeleportationItem.cs 
	/// </summary>
	public void Drop(GameObject itemDropping, Vector3 ogPos, Quaternion ogRot)
	{
		// put item back in its og pos and rot
		itemDropping.transform.localPosition = ogPos;
		itemDropping.transform.localRotation = ogRot;

		// change scene to mainscene 
		SceneTransition(mainVp, mainScene, mainSkybox);

		// set active every item
		foreach(GameObject item in itemList)
		{
			if (item.activeSelf) continue;
			item.SetActive(true);
		}
	}

	/// <summary>
	/// transition to chosen scene
	/// </summary>
	private void SceneTransition(VolumeProfile vp, GameObject newScene, Material skybox)
	{
		// transition animation or something
		TimeTravelTransition();

		// change cur scene to newScene
		newScene.SetActive(true);
		currentScene.SetActive(false);
		currentScene = newScene;

		// change vp for scene
		globalVolume.sharedProfile = vp;

		// change skybox of the camera if there is a skybox
		RenderSettings.skybox = skybox;
	}

	/// <summary>
	/// is basically the transition when you travel to different scenes
	/// TODO: implement this
	/// </summary>
	private void TimeTravelTransition()
	{
		changeFOV = 1;
		// add transition distrotion or something. maybe use gobal volume for this
		// idk its up to who wants to do this

		// audio when transition idk 
		return;	
	}

	// Update is called once per frame
	void Update() {
		// TODO: maybe change idk though i think its designers choice
		// transition method idk what we wanna do its like a 
		// design thing tbh
		if (changeFOV > 0) {
			changeFOV++;
			if (changeFOV > 500) {
				changeFOV = 0;
				camera.fieldOfView = fov;
			} else {
				camera.fieldOfView += 0.1f;
			}
		}
	}
}