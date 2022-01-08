namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    public class ScrewMechanisum : MonoBehaviour
    {
        public bool canMove;
        public GunShoot gunShoot;


        // Update is called once per frame
        void Update()
        {


            if (transform.localPosition.y > 0.96f && canMove)
            {
                transform.Rotate(new Vector3(0, 1, 0), 10f);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - .0001f, transform.localPosition.z);

            }


        }

        private void OnTriggerEnter(Collider other)
        {
            if (gunShoot.canDrill)
            {
                canMove = true;
            }
            else
            {
                canMove = false;
            }
           
        }
        private void OnTriggerExit(Collider other)
        {
            canMove = false;
        }
    }

}


