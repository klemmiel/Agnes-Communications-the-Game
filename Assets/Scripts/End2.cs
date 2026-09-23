using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class End2 : MonoBehaviour
{
    public GameObject WinScreen;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            WinScreen.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
