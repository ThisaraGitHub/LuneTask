
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
        public GameObject exitButton;
        public ScrewMechanisum screwMechanisum;

        private VRTK_SnapDropZone snapDropZone;
        private bool isSnapped = false;

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
                ShowNotification(NotificationState.FINAL);
            }
        }

        private void SnapDropZone_ObjectSnappedToDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Snapped To DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
            if (!isSnapped)
            {
                ShowNotification(NotificationState.SECOND);
                isSnapped = true;
            }
        }

        private void SnapDropZone_ObjectUnsnappedFromDropZone(object sender, SnapDropZoneEventArgs e)
        {
            print("Object Unsnapped From DropZone");
            FindObjectOfType<SoundManager>().Play("Snap");
        }

        IEnumerator InstructionPannelCoroutine()
        {
            yield return new WaitForSeconds(1);
            ShowNotification(NotificationState.FIRST);
        }

        public void DisableAllNotification()
        {
            fisrstInstructionPannel.SetActive(false);
            secondInstructionPannel.SetActive(false);
            finalInstructionPannel.SetActive(false);
        }

        public void ShowNotification(NotificationState state)
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

    public enum NotificationState 
    {
        FIRST,SECOND,FINAL
    }
}