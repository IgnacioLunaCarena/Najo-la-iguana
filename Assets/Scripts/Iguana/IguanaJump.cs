using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaJump : MonoBehaviour
{
    [SerializeField] private IguanaData iguanaData;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    private Rigidbody rbIguana;
    private Animator anim;

    void Start()
    {
        rbIguana = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        //Debug.Log(IsGrounded());
        if (IsGrounded() && Input.GetButtonDown("Jump"))
            Jump();
    }

    private void Jump()
    {
        anim.SetTrigger("Jump");
        rbIguana.AddForce(Vector3.up * iguanaData.jumpForce, ForceMode.Impulse);
    }

    public bool IsGrounded()
    {
        return Physics.Raycast(groundCheck.position, Vector3.down, iguanaData.rayCastDistance, groundLayer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawRay(groundCheck.position, new Vector3(0f, -iguanaData.rayCastDistance, 0f));
    }
}
