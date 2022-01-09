namespace VRTK
{
    using UnityEngine;

    public class DrillMechanisam : MonoBehaviour
    {
        /// <summary>
        // This script handles the drill mechanisam //
        /// </summary>
       
        public VRTK_InteractableObject linkedObject;                                            // Reference to the VRTK Interactable obejct
        public bool canDrill = false;                                                           // Set drill's initial state 
        public RotateDrilHead rotateDrilHead;                                                   // Reference to the RotateDillHead class

        private void Start()
        {
            linkedObject = GetComponent<VRTK_InteractableObject>();                             // Initializing VRTK Interactable obejct
            linkedObject.InteractableObjectUsed += EnableDrill;                                 // Subscrbe the Interactable Object Used
            linkedObject.InteractableObjectUnused += DisableDrill;                              // Subscrbe the Interactable Object Unused
        }

        protected virtual void OnDisable()                                                      // Unsubscribing for the performance
        {
            linkedObject.InteractableObjectUsed -= EnableDrill;
            linkedObject.InteractableObjectUnused -= DisableDrill;
        }

        public void EnableDrill(object sender, InteractableObjectEventArgs e)                   // Handle when trigger pressed
        {
            canDrill = true;
            rotateDrilHead.canRotate = true;
            FindObjectOfType<SoundManager>().Play("DrillStart");
        }

        protected virtual void DisableDrill(object sender, InteractableObjectEventArgs e)        // Handle when trigger released
        {
            canDrill = false;
            rotateDrilHead.canRotate = false;
            FindObjectOfType<SoundManager>().Stop("DrillStart");
            FindObjectOfType<SoundManager>().Play("DrillEnd");
        }

    }
}