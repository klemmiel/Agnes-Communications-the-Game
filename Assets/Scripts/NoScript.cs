using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class NoScript : MonoBehaviour
{
    GameObject TrapDoor;
    public GameObject NO;
    // Start is called before the first frame update
    void Start()
    {
        TrapDoor = GameObject.Find("TrapDoor");
        TrapDoor.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == NO)
        {
            TrapDoor.SetActive(false);
        }
    }
}
