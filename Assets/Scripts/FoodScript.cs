using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class FoodScript : MonoBehaviour
{

    public float speed = 2f;


    // Get bottom and top Y positions of the camera view.
    void Start()
    {
        float bottomY = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        float topY = Camera.main.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

    }

    // Move left at a constant speed.
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;

        if (transform.position.x < -25f)
        {

            Destroy(gameObject);


        }


    }
    



}



