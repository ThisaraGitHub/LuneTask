namespace VRTK
{
    using UnityEngine;

    public class GunShoot : MonoBehaviour
    {
        public VRTK_InteractableObject linkedObject;
        public VRTK_ControllerEvents controllerEvents;
        public GameObject projectile;
        public Transform projectileSpawnPoint;
        public float projectileSpeed = 1000f;
        public float projectileLife = 5f;
        public bool canDrill = false;

        public RotateDrilHead rotateDrilHead;

        private void Start()
        {
            linkedObject = GetComponent<VRTK_InteractableObject>();
            linkedObject.InteractableObjectUnused += EnableDrill; 
            linkedObject.InteractableObjectUsed += DisableDrill;
        }

        //protected virtual void OnEnable()
        //{
        //    linkedObject = (linkedObject == null ? GetComponent<VRTK_InteractableObject>() : linkedObject);
        //    //  trackedControllerEventHandler = GetComponent<VRTKTrackedControllerEventHandler>();

        //    if (linkedObject != null)
        //    {
        //        linkedObject.InteractableObjectUsed += InteractableObjectUsed;
        //        VRTK_InteractGrab.ObjectAdded += CheckDrill;
        //    }
        //}



        protected virtual void OnDisable()
        {
            linkedObject.InteractableObjectUnused -= EnableDrill;
            linkedObject.InteractableObjectUsed -= DisableDrill;
            //if (linkedObject != null)
            //{
            //    linkedObject.InteractableObjectUsed -= DisableDrill;
            //}
        }

        public void EnableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = false;
            //Spond on
        }

        protected virtual void DisableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = true;
            //Spond off
        }

    }
}