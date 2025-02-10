using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IguanaMove : MonoBehaviour
{
    [SerializeField] private IguanaData iguanaData;
    [SerializeField] private Transform cam;
    [SerializeField] private float turnSmoothTime = .1f;
    private Animator animPlayer;
    private Rigidbody rbIguana;
    private Vector3 direction;
    private float turnSmoothVelocity;

    void Start()
    {
        animPlayer = GetComponent<Animator>();
        rbIguana = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        //Debug.Log(rbIguana.velocity);

        if (Input.GetKey(KeyCode.LeftShift))
            SpeedBoost();
        else
            NormalSpeed();
    }

    private void FixedUpdate()
    {
        MoveAndRotate();
    }

    private void MoveAndRotate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized;
        animPlayer.SetFloat("Run", direction.magnitude);

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            rbIguana.AddForce(moveDir * iguanaData.speed, ForceMode.Force);
            //transform.position += moveDir * data.speed * Time.deltaTime;
            //animPlayer.SetBool("isRun", true);
        }
    }

    private void SpeedBoost()
    {
        iguanaData.speed = 550;
        animPlayer.speed = 1.68f;
    }

    private void NormalSpeed()
    {
        iguanaData.speed = 275;
        animPlayer.speed = 1;
    }

    public Vector3 GetDirecion()
    {
        return direction;
    }
}
