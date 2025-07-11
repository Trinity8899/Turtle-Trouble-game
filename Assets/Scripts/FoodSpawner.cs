using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public GameObject[] food;
    public float spawnRate = 2;
    private float timer = 0;
    private float spawnHighy = 7.8f;
    private float spawnLowy = -8.2f;
    private float spawnRightx = 20f;
    private float spawnLeftx = 10f;

    
    void Start()
    {
        spawnFood();
    }

    
    void Update()
    {
        if (timer < spawnRate)
        {

            timer += Time.deltaTime;

        }
        else
        {
            spawnFood();
            timer = 0;
        }

        
    }

    void spawnFood()
    {

        // Randomly select a prefab from the array.
        int index = Random.Range(0, food.Length);

        // andom position within the specified range.
        float randomX = Random.Range(spawnRightx, spawnLeftx);
        float randomY = Random.Range(spawnLowy, spawnHighy);

        Instantiate(food[index], new Vector3(randomX, randomY, 0), Quaternion.identity);
    }



}
  
