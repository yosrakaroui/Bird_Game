using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrength;
    public LogicScript logic;
    public bool birdIsAlive = true;
    public AudioSource audioSource;
    public AudioClip flapSound;
    public SpriteRenderer wingRenderer;
    public Sprite wingUpSprite;
    public Sprite wingDownSprite;
    public float wingAnimationDuration = 0.14f;
    private Coroutine wingAnimationRoutine;
    public SpriteRenderer birdSprite;
    public float flapFlashDuration = 0.12f;
    public Color flapFlashColor = new Color(1f, 0.86f, 0.35f, 1f);
    private Color originalSpriteColor = Color.white;
    private Coroutine flapFlashRoutine;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        if (birdSprite == null)
        {
            birdSprite = GetComponent<SpriteRenderer>();
        }

        if (birdSprite != null)
        {
            originalSpriteColor = birdSprite.color;
        }

        if (wingRenderer != null && wingUpSprite != null && wingDownSprite != null)
        {
            wingAnimationRoutine = StartCoroutine(animateWings());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && birdIsAlive)
        {
            myRigidbody.velocity = Vector2.up * flapStrength;
            if (birdSprite != null)
            {
                if (flapFlashRoutine != null)
                {
                    StopCoroutine(flapFlashRoutine);
                }
                flapFlashRoutine = StartCoroutine(flashOnFlap());
            }

            if (audioSource != null && flapSound != null)
            {
                audioSource.PlayOneShot(flapSound);
            }
        }
    }

    private IEnumerator animateWings()
    {
        while (birdIsAlive)
        {
            wingRenderer.sprite = wingUpSprite;
            yield return new WaitForSeconds(wingAnimationDuration);
            wingRenderer.sprite = wingDownSprite;
            yield return new WaitForSeconds(wingAnimationDuration);
        }

        wingRenderer.sprite = null;
    }

    private IEnumerator flashOnFlap()
    {
        birdSprite.color = flapFlashColor;
        yield return new WaitForSeconds(flapFlashDuration);
        birdSprite.color = originalSpriteColor;
        flapFlashRoutine = null;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!birdIsAlive) return;

        birdIsAlive = false;
        logic.gameOver();
    }
}
