using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnScript : MonoBehaviour
{
    public GameObject pipe;
    public float spawnRate = 2;
    private float timer = 0;
    public float heightOffset = 3;
    public float moveSpeed = 5;
    public Color pipeTint = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0)
        {
            return;
        }

        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer -= spawnRate;
        }

    }

    void spawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        GameObject spawnedPipe = Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
        PipeMoveScript movement = spawnedPipe.GetComponent<PipeMoveScript>();
        if (movement != null)
        {
            movement.moveSpeed = moveSpeed;
        }

        SpriteRenderer[] renderers = spawnedPipe.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in renderers)
        {
            spriteRenderer.color = pipeTint;
        }
    }
}
