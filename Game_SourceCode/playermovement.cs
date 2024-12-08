using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    Vector3 movement;
    Animator anim;
    float rotatespeed = 20f;
    Quaternion rotation;
    Rigidbody rb;
    AudioSource footstep;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        footstep = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        movement.Set(horizontal,0f,vertical);
        movement.Normalize();

        bool hashorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasverticalInput = !Mathf.Approximately(vertical, 0f);

        bool iswalking = (hashorizontalInput || hasverticalInput);
        anim.SetBool("iswalking", iswalking);

        Vector3 rotatedirection = Vector3.RotateTowards(transform.forward, movement, rotatespeed * Time.deltaTime, 0f);
        
        rotation = Quaternion.LookRotation(rotatedirection);

        if (iswalking)
        {
            if (!footstep.isPlaying)
            {
                footstep.Play();
            }
        }
        else
        {
            footstep.Stop();
        }
        
    }
    void OnAnimatorMove()
    {
        rb.MovePosition(rb.position + movement * anim.deltaPosition.magnitude);
        rb.MoveRotation(rotation);
    }

}
