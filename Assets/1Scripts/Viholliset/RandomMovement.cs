using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour {

    public float maxDistance;
    public float minTime;
    public float maxTime;
    Vector3 startingPoint;
    Vector3 randomDirection;
    Rigidbody rb;
    float acceleration;
    float maxSpeed;

    void Start () {
        startingPoint = transform.position;
        StartCoroutine(move());
        rb = GetComponent<Rigidbody>();
        maxSpeed = GetComponent<vihollistenLiikuminen>().maxNopeus;
        acceleration = GetComponent<vihollistenLiikuminen>().kiihtyvyys;
    }

    void Update()
    {
        rb.AddForce(randomDirection.normalized * acceleration);
        if (rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * maxSpeed;
        }

        if (Mathf.Round(transform.position.x) == Mathf.Round((startingPoint + randomDirection).x) && Mathf.Round(transform.position.z) == Mathf.Round((startingPoint + randomDirection).z))
        {
            randomDirection = Vector3.zero;
        }
    }

    IEnumerator move()
    {
        SetRandomPlace();
        yield return new WaitForSeconds(Random.Range(minTime, maxTime));
        StartCoroutine(move());
    }

    void SetRandomPlace()
    {
        float distance = Random.Range(0, maxDistance);
        float randomX = Random.Range(0, distance);
        float randomZ = Mathf.Sqrt(Mathf.Pow(distance, 2) - Mathf.Pow(randomX, 2));
        Vector3 possibleDirection = new Vector3(randomX, 0, randomZ);
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
        if (didWeHitSomething)
        {
            SetRandomPlace();
        }
        else
        {
            randomDirection = possibleDirection;
        }
    }
}
