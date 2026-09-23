using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkAnimation : MonoBehaviour
{
    public SpriteRenderer sr;
    public Sprite[] walkFrames;
    public float frameRate = 0.15f;

    private int currentFrame = 0;
    private float timer = 0f;

    void Update()
    {
        float move = Input.GetAxisRaw("Horizontal");

        if (move != 0)
        {
            timer += Time.deltaTime;

            if (timer >= frameRate)
            {
                currentFrame++;
                if (currentFrame >= walkFrames.Length)
                    currentFrame = 0;

                sr.sprite = walkFrames[currentFrame];
                timer = 0f;
            }
        }
        else
        {
            sr.sprite = walkFrames[0];
        }
    }
}
