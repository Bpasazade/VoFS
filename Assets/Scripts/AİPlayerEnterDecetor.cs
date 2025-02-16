using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SVS.AI
{
    public class AİPlayerEnterDecetor : MonoBehaviour
    {
        public string playerTag = "Player";

        Animator animator;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag(playerTag))
            {
                
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag(playerTag))
            {
                collision.transform.parent = null;
            }
        }

    }
}

