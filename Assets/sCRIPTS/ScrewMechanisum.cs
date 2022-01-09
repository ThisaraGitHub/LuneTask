namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;



    public class ScrewMechanisum : MonoBehaviour
    {
        public bool canMove;
        public bool isReachedtheEnd = false;
        public DrillMechanisam drillMechanisam;
        public NotificationManager notificationManager;
        public GameObject dustParticle;
        // Update is called once per frame
        void Update()
        {


            if (transform.localPosition.y > 0.96f && canMove)
            {
                transform.Rotate(new Vector3(0, 1, 0), 10f);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - .0001f, transform.localPosition.z);
                print("-------" + transform.localPosition.y);
                dustParticle.SetActive(true);

                if (transform.localPosition.y == 0.9599925f)
                {
                    print("ENDDDDDDDDDDDDD");
                    isReachedtheEnd = true;
                    dustParticle.SetActive(false);
                    //  notificationManager.ActivateFinalNotification();
                }
            }

            //if (isReachtheEnd) 
            //{
            //   

            //}
            //if(transform.localPosition.y == 0.96f) 
            //{
            //    //Game over
            //}


        }

        private void OnTriggerEnter(Collider other)
        {
            if (drillMechanisam.canDrill)
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


