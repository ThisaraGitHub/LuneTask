
namespace VRTK
{

    using UnityEngine;

    public class NotificationManager : MonoBehaviour
    {
        public GameObject snapObject;
        private VRTK_SnapDropZone snapDropZone;

        private void Start()
        {
            snapDropZone = snapObject.GetComponent<VRTK_SnapDropZone>();
            snapDropZone.ObjectSnappedToDropZone += SnapDropZone_ObjectSnappedToDropZone;
            snapDropZone.ObjectUnsnappedFromDropZone += SnapDropZone_ObjectUnsnappedFromDropZone;

        }


        private void SnapDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Snapped To DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
        }

        private void SnapDropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Unsnapped From DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
        }
    }
}