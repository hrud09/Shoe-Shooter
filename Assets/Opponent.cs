using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Opponent : MonoBehaviour
{
    public Transform target;
    float speed;
    public float mainSpeed;
    Rigidbody rb;
    public bool hasTarget;
    [SerializeField] float RotationSpeed;
    Animator anim;
    [SerializeField] LayerMask playerLayer;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = mainSpeed;
        anim = GetComponentInChildren<Animator>();

    }

    private void Update()
    {
     
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!hasTarget)
        {
            
            if (Physics.OverlapSphere(transform.position, 6, playerLayer).Length > 0)
            {
                hasTarget = true;
                anim.SetBool("Run", true);
            }

        }
        else
        {
           
            Vector3 direction = target.position - transform.position;
           // if (direction.magnitude>4)
           // {
                rb.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), RotationSpeed * Time.deltaTime);
                rb.velocity = transform.forward * speed * 10 * Time.fixedDeltaTime;
           // }
           // else
           // {
                //Jump
          //  }
           
        }
      
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.layer == 8)
        {
            anim.SetBool("Run", false);
            StartCoroutine(ResetSpeed());
        }
    }
    IEnumerator ResetSpeed()
    {
        speed = 0;
        yield return new WaitForSeconds(1);
        speed /= 2;
        yield return new WaitForSeconds(1);
        speed = mainSpeed;


    }
}
