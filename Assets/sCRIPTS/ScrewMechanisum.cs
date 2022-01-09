namespace VRTK
{
    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class ScrewMechanisum : MonoBehaviour
    {
        /// <summary>
        // This script handles the screw mechanisam  //
        /// </summary>

        public bool canDrill;                                                           // Boolean reference to the enablle and disbale drilling
        public bool isReachedtheEnd = false;                                            // Reference that screw has gone to the end
        public DrillMechanisam drillMechanisam;                                         // Reference to the drill mechanisam script
        public NotificationManager notificationManager;                                 // Reference to the drill notification manager script
        public GameObject dustParticle;                                                 // Reference to the particle effect

        // Update is called once per frame
        void Update()
        {
            if (transform.localPosition.y > 0.96f && canDrill)
            {
                transform.Rotate(new Vector3(0, 1, 0), 10f);
                transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y - .0001f, transform.localPosition.z);    // Set the position of the screw

                if (transform.localPosition.y == 0.9599925f)
                {
                    isReachedtheEnd = true;
                }
            }
        }

        private void OnTriggerEnter(Collider other)                                       // Checking the drill head and screw are triggered 
        {
            if (drillMechanisam.canDrill)
            {
                dustParticle.SetActive(true);
                canDrill = true;
            }
            else
            {
                dustParticle.SetActive(false);
                canDrill = false;
            }

        }
        private void OnTriggerExit(Collider other)                                          // Checking the drill head and screw are not triggered 
        {
            dustParticle.SetActive(false);
            canDrill = false;
        }
    }

}


