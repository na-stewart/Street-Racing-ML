using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{

    public float speed;
    private Vector3 startPosition;
    private Quaternion startRotation;
    private Rigidbody rigidBody;

    // Start is called before the first frame update

    private void Start()
    {       
        rigidBody = GetComponent<Rigidbody>();
        startPosition = transform.position;
        startRotation = transform.rotation;
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
      
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Point")
            Physics.IgnoreCollision(collision.gameObject.GetComponent<Collider>(), gameObject.GetComponent<Collider>());
        else
        {
            rigidBody.isKinematic = true;
            transform.position = startPosition;
            transform.rotation = startRotation;
            rigidBody.isKinematic = false;
        }
    }
}
