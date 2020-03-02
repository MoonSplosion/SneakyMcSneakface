using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Keep track of transform
    private Transform tf;
    //Track Enemy Health
    public float AIHealth;
    //Track Enemy State
    public string AIState = "Idle";
    //Track attack range
    public float AIRange;
    //Track health cutoff
    public float HPCutoff;
    //Track target location
    public Transform Target;
    //AI Speed
    public float speed = 5.0f;
    //Track Healing rate per second
    public float restingHealRate = 1.0f;
    //Max HP
    public float MaxHP = 100.0f;

    public float fieldOfView = 45f;
    // Start is called before the first frame update
    void Start()
    {
        tf = gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        CanHear(GameManager.instance.Player);
        if (AIState == "Idle")
        {
            Idle();

            //Check for transitions
            if (isInRange())
            {
                ChangeState("Seek");
            }
        }
        else if (AIState == "Rest")
        {
            //do state bevavior
            Rest();
            if (AIHealth >= HPCutoff)
            {
                ChangeState("Idle");
            }
        }
        else if (AIState == "Seek")
        {
            Seek();
            if (AIHealth <= HPCutoff)
            {
                Rest();
            }

            if (!isInRange())
            {
                ChangeState("Idle");
            }
        }
        else
        {
            Debug.LogError("State does not exist: " + AIState);
        }
    }

    public void Idle()
    {
        //Do Nothing

    }

    public void Rest()
    {
        //Stand still

        //Heal
        AIHealth += restingHealRate * Time.deltaTime;
        AIHealth = Mathf.Min(AIHealth, MaxHP);
    }

    public void Seek()
    {
        //Move towards player
        Vector3 vectortoTarget = Target.position - tf.position;
        tf.position += vectortoTarget.normalized * speed * Time.deltaTime;
    }

    public void ChangeState(string newState)
    {
        AIState = newState;
    }

    public bool isInRange()
    {
        return (Vector3.Distance(tf.position, Target.position) <= AIRange);
    }

    public bool CanHear(GameObject target)
    {
        //get noisemaker from target
        NoiseMaker noise = target.GetComponent<NoiseMaker>();
        // if there is a noisemaker, potentially hear target
        if (noise != null)
        {
            float adjustedVolumeDistance =
                noise.volumeDistance - Vector3.Distance(tf.position, target.transform.position);
            if (adjustedVolumeDistance > 0)
            {
                Debug.Log("I Heard the noise");
                return true;
            }
        }
        return false;
    }

    public bool CanSee(GameObject target)
    {
        Vector3 vectorToTarget = target.transform.position - tf.position;
        //detect if target is inside fov
        float angleToTarget = Vector3.Angle(vectorToTarget, tf.up);
        //detect if target is in line if sight
        if (angleToTarget <= fieldOfView)
        {

        }
        return false;
    }
}

