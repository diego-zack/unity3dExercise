using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    public Rigidbody plataformRB;
    public Transform[] target;
    public float PlataformSpeed = 6.0f;
    
    private int currentPosition = 0;
    private int nextPosition = 1;

    void Update()
    {
        MovePlataform();
    }

    void MovePlataform()
    {
        plataformRB.MovePosition(Vector3.MoveTowards(plataformRB.position, target[nextPosition].position, PlataformSpeed * Time.deltaTime));
        if (Vector3.Distance(plataformRB.position, target[nextPosition].position) <= 0)
        {
            currentPosition = nextPosition;
            nextPosition++;
            if (nextPosition > target.Length - 1)
                nextPosition = 0;
        }
    }
}
