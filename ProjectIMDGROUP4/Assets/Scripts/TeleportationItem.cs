using UnityEngine;
using UnityEngine.Rendering;

public class TeleportationItem : MonoBehaviour
{
    [SerializeField]
    AIOManager manager;
    [SerializeField]
    GameObject connectedScene;
    [SerializeField]
    VolumeProfile vp;
    [SerializeField]
    Material skybox;
    private Vector3 ogPos;
    private Quaternion ogRot;

    void Start()
    {
        // gets initial pos and rot
        ogPos = this.gameObject.transform.position;
        ogRot = this.gameObject.transform.rotation;
    }

    /// <summary>
    /// gets called in XRGrabInteractable in the Select Entered
    /// </summary>
    public void OnPickup()
    {
        manager.Pickup(connectedScene, this.gameObject, vp, skybox);
    }

    /// <summary>
    /// gets called in XRGrabInteractable in the Select Exit
    /// </summary>
    public void OnDrop()
    {
        manager.Drop(this.gameObject, ogPos, ogRot);
    }
}
