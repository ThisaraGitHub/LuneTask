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
            linkedObject.InteractableObjectUnused += DisableDrill; 
            linkedObject.InteractableObjectUsed += EnableDrill;
        }



        protected virtual void OnDisable()
        {
            linkedObject.InteractableObjectUnused -= DisableDrill;
            linkedObject.InteractableObjectUsed -= EnableDrill;
        }

        public void EnableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = true;
            canDrill = true;
            //Spond on
        }

        protected virtual void DisableDrill(object sender, InteractableObjectEventArgs e)
        {
            rotateDrilHead.canRotate = false;
            canDrill = false;
            //Spond off
        }

    }
}