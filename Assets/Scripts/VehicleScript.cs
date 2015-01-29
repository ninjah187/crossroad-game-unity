using UnityEngine;
using System.Collections;

public class VehicleScript : MonoBehaviour
{
    private delegate void MoveHandler();

    public float speed = 10;
    public float maxSpeed = 10;
    public Vector3 forwardVector = new Vector3(0, 0, 1);

    private MoveHandler move;
    private MoveHandler brake;
    private MoveHandler stop;

    private MoveHandler moveHandler;

	// Use this for initialization
	void Start ()
	{
	    move = () =>
	    {
	        if (rigidbody.velocity.magnitude < maxSpeed)
	        {
	            rigidbody.AddForce(speed*forwardVector);
	        }
	    };
	    brake = () =>
	    {
	        if (rigidbody.velocity.magnitude > 0.2f)
	        {
	            rigidbody.AddForce(-2f * speed * forwardVector);
	        }
	        else
	        {
                rigidbody.velocity = new Vector3(0, 0, 0);
	            moveHandler = stop;
	        }
	    };
	    stop = () =>
	    {
            
	    };
        
	    moveHandler = move;
	}
	
	// Update is called once per frame
	void Update () {
	    if (transform.position.z > 50)
	    {
	        transform.position = new Vector3(transform.position.x,
                transform.position.y,
                -50f
                );
	        return;
	    }
	    if (transform.position.z < -50)
	    {
            transform.position = new Vector3(transform.position.x,
                transform.position.y,
                50f
                );
	    }
	}

    void FixedUpdate()
    {
        //rigidbody.AddForce(Vector3.forward * speed);
        moveHandler();
    }

    void OnCollisionEnter(Collision collision)
    {
        rigidbody.useGravity = true;
        moveHandler = stop;
    }

    void OnTriggerEnter(Collider collider)
    {
        /*if (moveHandler == move)
        {
            moveHandler = brake;
            return;
        }
        if (moveHandler == brake)
        {
            moveHandler = move;
        }*/
        
    }

    void OnTriggerStay(Collider collider)
    {
        /*if (moveHandler == move)
        {
            moveHandler = brake;
            return;
        }
        if (moveHandler == brake)
        {
            moveHandler = move;
        }*/
        var faster = rigidbody.velocity.magnitude > collider.attachedRigidbody.velocity.magnitude
            ? rigidbody
            : collider.attachedRigidbody;
        //faster.gameObject.SetActive(false);
        faster.AddRelativeForce(0, 0, -100);
    }

    /*void OnTriggerEnter(Collider otherCollider)
    {
        //moveHandler = brake;
        //otherCollider.gameObject.SetActive(false);
        //otherCollider.gameObject.SetActive(false);
        
    }

    void OnTriggerStay(Collider otherCollider)
    {
        var velocity = otherCollider.attachedRigidbody.velocity.magnitude;
        moveHandler = brake;
    }*/
}
