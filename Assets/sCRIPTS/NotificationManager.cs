
namespace VRTK
{
    using System.Collections;
    using UnityEngine;

    public class NotificationManager : MonoBehaviour
    {
        public GameObject fisrstInstructionPannel;
        public GameObject secondInstructionPannel;
        public GameObject finalInstructionPannel;
        public GameObject snapObject;
        public ScrewMechanisum screwMechanisum;
        private VRTK_SnapDropZone snapDropZone;


        private void Start()
        {
            snapDropZone = snapObject.GetComponent<VRTK_SnapDropZone>();
            snapDropZone.ObjectSnappedToDropZone += SnapDropZone_ObjectSnappedToDropZone;
            snapDropZone.ObjectUnsnappedFromDropZone += SnapDropZone_ObjectUnsnappedFromDropZone;

            StartCoroutine(InstructionPannelCoroutine());

        }
        private void Update()
        {
            if (screwMechanisum.isReachedtheEnd) 
            {
                ActivateFinalNotification();
            }
        }


        private void SnapDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Snapped To DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
            ActivateSecondNotification();
        }

        private void SnapDropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Unsnapped From DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
        }

        IEnumerator InstructionPannelCoroutine()
        {
            yield return new WaitForSeconds(1);
            ActivateFirstNotification();


        }

        private void ActivateFirstNotification()
        {
            fisrstInstructionPannel.SetActive(true);
            secondInstructionPannel.SetActive(false);
            FindObjectOfType<SoundManager>().Play("Notification");
        }
        private void ActivateSecondNotification()
        {
            fisrstInstructionPannel.SetActive(false);
            secondInstructionPannel.SetActive(true);
            FindObjectOfType<SoundManager>().Play("Notification");
        }

        public void ActivateFinalNotification()
        {
            fisrstInstructionPannel.SetActive(false);
            secondInstructionPannel.SetActive(false);
            finalInstructionPannel.SetActive(true);
            FindObjectOfType<SoundManager>().Play("Notification");
        }
    }
}