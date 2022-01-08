namespace VRTK
{
    using UnityEngine;

    public class DrillMechanisam : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public bool canDrill = false;
        public RotateDrilHead rotateDrilHead;

        private void Start()
        {
            linkedObject = GetComponent<VRTK_InteractableObject>();
            linkedObject.InteractableObjectUsed += EnableDrill;
            linkedObject.InteractableObjectUnused += DisableDrill; 
        }



        protected virtual void OnDisable()
        {
            linkedObject.InteractableObjectUsed -= EnableDrill;
            linkedObject.InteractableObjectUnused -= DisableDrill;
        }

        public void EnableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = true;
            canDrill = true;
            //Spond on
            FindObjectOfType<SoundManager>().Play("DrillStart");
        }

        protected virtual void DisableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = false;
            canDrill = false;
            //Spond off
            FindObjectOfType<SoundManager>().Stop("DrillStart");
            FindObjectOfType<SoundManager>().Play("DrillEnd");
        }

    }
}