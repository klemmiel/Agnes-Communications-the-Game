using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeed : MonoBehaviour
{
    public float speedMultiplier = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement pm = collision.GetComponent<PlayerMovement>();

            if (pm != null)
            {
                pm.walkSpeed *= speedMultiplier;
            }

            SpeedGhost ghost = collision.GetComponent<SpeedGhost>();
            if (ghost != null)
            {
                ghost.StartGhosting();
            }

        }
    }
}


