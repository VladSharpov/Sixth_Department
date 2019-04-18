using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] float moveSpeed = 500f;
    [SerializeField] Transform target1;
    [SerializeField] Transform target2;

    Transform currentTarget;

    bool isMoving = false;

    private void Awake()
    {
        currentTarget = target1;
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitAndMove());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        WaitAndChangeDirection();
    }

    private void WaitAndChangeDirection()
    {
        if (Vector3.Distance(transform.position, currentTarget.position) < .001f)
        {
            isMoving = false;
            currentTarget = (currentTarget == target1) ? target2 : target1;
            StartCoroutine(WaitAndMove());
        }
    }

    IEnumerator WaitAndMove()
    {
        yield return new WaitForSeconds(Random.Range(5f, 10f));
        isMoving = true;
    }

    private void Move()
    {
        if (isMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, Time.fixedDeltaTime * moveSpeed);
        }
    }
}
