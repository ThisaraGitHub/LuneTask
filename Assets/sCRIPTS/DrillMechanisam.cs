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
            canDrill = true;
            rotateDrilHead.canRotate = true;
            FindObjectOfType<SoundManager>().Play("DrillStart");
        }

        protected virtual void DisableDrill(object sender, InteractableObjectEventArgs e)
        {
            canDrill = false;
            rotateDrilHead.canRotate = false;
            FindObjectOfType<SoundManager>().Stop("DrillStart");
            FindObjectOfType<SoundManager>().Play("DrillEnd");
        }

    }
}