using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPawn : Pawn
{
    // Start is called before the first frame update
    void Start()
    {
        Attack();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Attack()
    {
        Debug.Log("Player Attack");
        //base.Attack();
    }

}
