using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    public float RotationSpeed;
    Rigidbody rb;
    Vector3 Direction;
    Vector2 InitialPos;

    public Animator anim;


    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {

        if (rb == null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if (Input.GetMouseButtonDown(0))
        {
            InitialPos = Input.mousePosition;
            anim.SetLayerWeight(1, 1);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            InitialPos = Vector2.zero;
            rb.velocity = Vector3.zero;
            anim.SetLayerWeight(1, 0);
        }
        if (Input.GetMouseButton(0))
        {
            Direction= ((Vector2)(Input.mousePosition) - InitialPos);
        }

    }
    
    private void FixedUpdate()
    {

        if (Direction.magnitude >= 20f && Input.GetMouseButton(0))
        {
            Vector3 direction = new Vector3(Direction.x, 0, Direction.y);
            rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), RotationSpeed * Time.deltaTime);         
            rb.velocity = transform.forward * speed * 10 * Time.fixedDeltaTime;
            
        }
    }
   
}
