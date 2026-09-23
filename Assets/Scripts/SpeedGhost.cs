using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedGhost : MonoBehaviour
{
    public SpriteRenderer playerSprite;
    public float ghostDelay = 0.05f;
    public float ghostLifetime = 0.3f;
    public Color ghostColor = new Color(1f, 1f, 1f, 0.5f);

    private bool isGhosting = false;

    public void StartGhosting()
    {
        if (!isGhosting)
            StartCoroutine(GhostTrail());
    }

    public void StopGhosting()
    {
        isGhosting = false;
    }

    IEnumerator GhostTrail()
    {
        isGhosting = true;

        while (isGhosting)
        {
            GameObject ghost = new GameObject("Ghost");
            SpriteRenderer sr = ghost.AddComponent<SpriteRenderer>();

            sr.sprite = playerSprite.sprite;
            sr.flipX = playerSprite.flipX;
            sr.color = ghostColor;
            ghost.transform.position = transform.position;
            ghost.transform.localScale = transform.localScale;

            Destroy(ghost, ghostLifetime);

            yield return new WaitForSeconds(ghostDelay);
        }
    }
}
