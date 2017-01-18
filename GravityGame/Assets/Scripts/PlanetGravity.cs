using UnityEngine;
using System.Collections.Generic;

public class PlanetGravity : MonoBehaviour
{
    static float G = 0.01f; // adjust with try & error

    static List<Rigidbody> planets = new List<Rigidbody>();
    private Rigidbody myRigidbody;
    public Vector3 initialForwardSpeed;

    // Use this for initialization
    void Awake()
    {
        myRigidbody = GetComponent<Rigidbody>();
        myRigidbody.velocity = transform.TransformDirection(initialForwardSpeed);
    }


    void OnEnable()
    {
        planets.Add(myRigidbody);
    }

    void OnDisable()
    {
        planets.Remove(myRigidbody);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 pos = myRigidbody.position;
        Vector3 acc = Vector3.zero;
        foreach (Rigidbody planet in planets)
        {
            if (planet == myRigidbody)
                continue;
            Vector3 direction = (planet.position - pos);
            acc += G * (direction.normalized * planet.mass) / direction.sqrMagnitude;
        }
        myRigidbody.velocity += acc * Time.fixedDeltaTime;
    }
}