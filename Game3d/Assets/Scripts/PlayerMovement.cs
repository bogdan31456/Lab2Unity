using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public Transform cameraPosition;
    public float mouseSensitivity;
    public bool invertX;
    public bool invertY;
    //public float jumpHeight = 15f;
   private CharacterController characterController;
    private Vector3 movementVector;
    // Start is called before the first frame update
    void Start()
    {
        characterController=GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //movementVector.x=Input.GetAxis("Horizontal") * movementSpeed*Time.deltaTime;
        // movementVector.z=Input.GetAxis("Vertical")*movementSpeed*Time.deltaTime;
        //Vector3 movementVertical  = Input.GetAxis("Vertical") *transform.forward;
        //Vector3 movementHorizontal = Input.GetAxis("Horizontal") * transform.right;
        Vector3 movementVertical = transform.forward * Input.GetAxis("Vertical");
        Vector3 movementHorizontal = transform.right * Input.GetAxis("Horizontal");
        movementVector = movementHorizontal + movementVertical;
        movementVector.Normalize();
        movementVector = movementVector * movementSpeed * Time.deltaTime;


        characterController.Move(movementVector);
        Vector2 mouseVector = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;
        if (invertX)
        {
            mouseVector.x = -mouseVector.x;
        }
        if (invertY)
        {
            mouseVector.y = -mouseVector.y;
        }
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + mouseVector.x, transform.rotation.eulerAngles.z);
        cameraPosition.rotation = Quaternion.Euler(cameraPosition.rotation.eulerAngles + new Vector3(mouseVector.y, 0f, 0f));
    }
}
