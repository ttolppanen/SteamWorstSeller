using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public float maxDistance;
    public float minTime;
    public float maxTime;
    Vector3 startingPoint;
    Vector3 randomPlace;
    Vector3 randomDirection;
    Rigidbody rb;
    float acceleration;
    float maxSpeed;
    EnStates states;

    void Start () {
        startingPoint = transform.position;
        StartCoroutine(move());
        rb = GetComponent<Rigidbody>();
        maxSpeed = GetComponent<vihollistenLiikuminen>().maxNopeus;
        acceleration = GetComponent<vihollistenLiikuminen>().kiihtyvyys;
        states = GetComponent<EnStates>();
    }

    void FixedUpdate()
    {
        if (states.isIdle)
        {
            rb.AddForce(randomDirection.normalized * acceleration);
        }
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }
    }

    private void Update()
    {
        if (Functions.OnWhichSide(transform.position - randomPlace, randomDirection)) //Jos ollaan menty ohi niin nollataan paikka että ei liikuta
        {
            randomDirection = Vector3.zero;
        }
    }

    IEnumerator move()
    {
        if (states.isIdle)
        {
            SetRandomPlace();
        }
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(move());
    }

    void SetRandomPlace()
    {
        float distance = Random.Range(0, maxDistance);
        float randomX = Random.Range(-distance, distance);
        float randomZ = Mathf.Sqrt(Mathf.Pow(distance, 2) - Mathf.Pow(randomX, 2));
        randomZ *= Mathf.Pow(-1, Random.Range(0, 2)); // Randomilla onko z suunta positiivinen vai negatiivinen
        Vector3 possibleDirection = new Vector3(randomX, 0, randomZ);
        print(randomX);
        print(randomZ);
        Ray ray = new Ray(transform.position, possibleDirection);
        RaycastHit[] hits = Physics.RaycastAll(ray, distance);
        bool didWeHitSomething = false;
        foreach(RaycastHit hit in hits)
        {
            if (hit.transform != transform)
            {
                didWeHitSomething = true;
                break;
            }
        }
        if (didWeHitSomething || (transform.position + possibleDirection - startingPoint).magnitude > maxDistance)
        {
            SetRandomPlace();
        }
        else
        {
            randomPlace = possibleDirection + transform.position;
            randomDirection = possibleDirection;
        }
    }
}
