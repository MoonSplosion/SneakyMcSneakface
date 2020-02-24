using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    private Transform tf;

    public float MoveSpeed = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        tf = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.up * Time.deltaTime * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.UpArrow))
        {
            tf.position -= tf.up * Time.deltaTime * MoveSpeed;
            tf.Rotate(0,0,180);
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.UpArrow))
        {
            tf.position -= tf.right * Time.deltaTime * MoveSpeed;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.UpArrow))
        {
            tf.position += tf.right * Time.deltaTime * MoveSpeed;
        }
    }
}
