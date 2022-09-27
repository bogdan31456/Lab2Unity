using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    public float jumpHeight = 5f;
    Vector2 movementVector;
    Rigidbody2D rbody;
    CapsuleCollider2D capsuleCollider;
    // Start is called before the first frame update
    void Start()
    {
        rbody = GetComponent<Rigidbody2D>();

    
        capsuleCollider = GetComponent<CapsuleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 plaverVelocity=new Vector2(movementVector.x*movementSpeed,rbody.velocity.y);
        rbody.velocity = plaverVelocity;
    }

    private void OnMove(InputValue value)
    {

        movementVector = value.Get<Vector2>();
        Debug.Log(movementVector);
    }
     private void OnJump(InputValue value)
    {
        /*if(value.isPressed)
        {
            rbody.velocity+=new Vector2(0f,jumpHeight);

        }*/
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) return;
        if (value.isPressed)
        {
            rbody.velocity += new Vector2(0f, jumpHeight);
        }




    }

}
