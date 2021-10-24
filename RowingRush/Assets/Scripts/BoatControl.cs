using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatControl : MonoBehaviour
{
    public GameObject camera;
    public GameObject boat;

    Vector3 oldPosition;
    Vector3 currentPosition;
    Vector3 targetPosition;


    void Start()
    {
        oldPosition = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        currentPosition = camera.transform.position;

        
        float distance = (currentPosition - oldPosition).magnitude * Time.deltaTime;
        Debug.Log(distance);
        boat.transform.Translate(0, 0, distance*13);
        oldPosition = currentPosition;
        
    }
}
