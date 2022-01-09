
namespace VRTK
{
    using System.Collections;
    using UnityEngine;

    public class NotificationManager : MonoBehaviour
    {
        /// <summary>
        // This script handles states of the notifications  //
        /// </summary>
        
        public GameObject fisrstInstructionPannel;                                                  // Reference to the 1st notification
        public GameObject secondInstructionPannel;                                                  // Reference to the 2nd notification
        public GameObject finalInstructionPannel;                                                   // Reference to the 3rd notification
        public GameObject snapObject;                                                               // Reference to the snapped object
        public GameObject exitButton;                                                               // Reference to the exit button
        public ScrewMechanisum screwMechanisum;                                                     // Reference to the screw mechanisam

        private VRTK_SnapDropZone snapDropZone;                                                     // Private reference to the snap drop zone
        private bool isSnapped = false;                                                             // Initial state snapping falsed

        private void Start()
        {
            snapDropZone = snapObject.GetComponent<VRTK_SnapDropZone>();                            // Initializing VRTK Snap Drop Zone
            snapDropZone.ObjectSnappedToDropZone += SnapDropZone_ObjectSnappedToDropZone;           // Subscrbe the VRTK Snap Drop Zone
            snapDropZone.ObjectUnsnappedFromDropZone += SnapDropZone_ObjectUnsnappedFromDropZone;   // Subscrbe the VRTK Object Unsnapped From Drop Zone
            StartCoroutine(InstructionPannelCoroutine());
        }

        private void Update()
        {
            if (screwMechanisum.isReachedtheEnd)                                                     // Display final popup
            {
                ShowNotification(NotificationState.FINAL);
            }
        }

        private void SnapDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)    // After snapped, things are handled here
        {
            print("Object Snapped To DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
            if (!isSnapped)
            {
                ShowNotification(NotificationState.SECOND);
                isSnapped = true;
            }
        }

        private void SnapDropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)   // After Unsnapped, things are handled here
        {
            print("Object Unsnapped From DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
        }

        IEnumerator InstructionPannelCoroutine()                                                         // Initial notification handles here
        {
            yield return new WaitForSeconds(1);
            ShowNotification(NotificationState.FIRST);
        }

        public void DisableAllNotification()                                                              // Disable all notifications
        {
            fisrstInstructionPannel.SetActive(false);
            secondInstructionPannel.SetActive(false);
            finalInstructionPannel.SetActive(false);
        }

        public void ShowNotification(NotificationState state)                                               // Handeling notifications states
        {
            DisableAllNotification();
            switch (state)
            {
                case NotificationState.FIRST:
                    fisrstInstructionPannel.SetActive(true);
                    break;
                case NotificationState.SECOND:
                    secondInstructionPannel.SetActive(true);
                    break;
                case NotificationState.FINAL:
                    finalInstructionPannel.SetActive(true);
                    exitButton.SetActive(true);
                    break;
            }
            FindObjectOfType<SoundManager>().Play("Notification");
        }
    }

    public enum NotificationState                                                                               // ENUM for the notification
    {
        FIRST,SECOND,FINAL
    }
}