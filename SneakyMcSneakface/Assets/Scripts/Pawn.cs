using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pawn : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public virtual void Attack()
    {
        Debug.Log("Pawn Attack");
    }
    public virtual void Move()
    {
        Debug.Log("Move With Pawn movement behavior");
    }
}
