using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public GameObject rtPlayer;

    public enum gamestate { Playing, GameOver };
    public gamestate state;

    // Start is called before the first frame update
    void Start()
    {
        rtPlayer = Camera.main.GetComponent<CameraLock>().rtPlayer; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
