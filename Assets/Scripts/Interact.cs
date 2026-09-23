using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class Interact : MonoBehaviour
{
    GameObject text;
    public GameObject box;


    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Question");
        text.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject == box)
        {
            text.SetActive(true);
        }
    }   
}