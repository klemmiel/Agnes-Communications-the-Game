using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLock : MonoBehaviour
{
    public GameObject rtPlayer;
    public float speed;
    void Start()
    {
        speed = 5f;
        transform.position = rtPlayer.transform.position;
    }

    private void Update()
    {
        if (this.transform.position.z != -10)
        {
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, -10f);
        }
    }

    void LateUpdate()
    {
         transform.position = Vector3.Lerp(transform.position, rtPlayer.transform.position - new Vector3(0, 0, 10), speed);
         if (Vector2.Distance(transform.position, rtPlayer.transform.position) < 1f && rtPlayer.CompareTag("Player")) speed = 5f;
    }
}
