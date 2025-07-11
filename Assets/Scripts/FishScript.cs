using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FishScript : MonoBehaviour
{
    public GameObject fish;
    private float fishSpeed = 2f;

    private float minY = -9f;
    private float maxY = 7f;
    private float verticalSmoothTime = 2f; // It takes time to follow the target Y.
    private float verticalVelocity = 0f;   // This is the speed handled by SmoothDamp.
    private float targetY;
    private float changeTimer = 0f;
    private float changeInterval = 2f;
    private float FishHorizontX = 13;
     void Start()
     {
        targetY = transform.position.y;
     }

    void Update()
    {

        FishMovement();
        DestroyFish();

    }
    
    void FishMovement()
    {
        // Swimming to the left.
        transform.Translate(Vector3.left * 2 * fishSpeed * Time.deltaTime);

        // Timed direction change.
        changeTimer += Time.deltaTime;
        
        // It distributes the range proportionally based on t.
        if (changeTimer >= changeInterval)
        { 
            float t = Random.Range(0f, 1f);
            targetY = Mathf.Lerp(minY, maxY, t); 
            changeTimer = 0f;
        }

        // Smooth, organic movement toward the target.
        Vector3 pos = transform.position;

        // Perlin noise vibration. 
        float noise = Mathf.PerlinNoise(Time.time * 0.5f, 0f);
        float offset = (noise - 0.5f) * 0.03f;

        // SmoothDamp instead of a sudden jump.
        pos.y = Mathf.SmoothDamp(pos.y, targetY, ref verticalVelocity, verticalSmoothTime) + offset;

        // Clamp keeps the fish's position on the vertical axis.
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;

        // Tilt: It can remain, softened if needed
        float tiltAngle = Mathf.Clamp(verticalVelocity * 6f, -6f, 6f);
        transform.rotation = Quaternion.Euler(0f, 0f, tiltAngle);


    }


    private void DestroyFish()
    {
        if (transform.position.x < -25)
        {
            SpawnFish();
            Destroy(gameObject); 
           
           
        }
           
    
    }
     
     void SpawnFish()
     {
        Instantiate(fish, new Vector3(FishHorizontX, Random.Range(minY, maxY), 0),transform.rotation);
       

     }







}

   























