using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    public event Action<int> onMoneyCollect;

    [SerializeField] private float firstLanePos;
    [SerializeField] private float lastLanePos;
    [SerializeField] private float sideSpeed;
    [SerializeField] private Transform selfTransform;

    private CharacterController characterController;
    private Vector3 move;
    private Vector3 gravity;

    private int laneNumber = 1;
    private int laneCount = 2;

    private float speed = 15;
    private float jumpForce = 12;

    private bool changeFrame;

    public Transform SelfTransform => selfTransform;


    private void Start()
    {
        gravity = Vector3.zero;
        characterController = GetComponent<CharacterController>();
        move = new Vector3(0, 0, 1);
    }

    private void FixedUpdate()
    {
        Run();
    }

    private void Run()
    {
        if (!GameController.isRun)
            return;
        
        if (characterController.isGrounded)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            gravity.y = jumpForce;
        }
        else
        {
            gravity += Physics.gravity * Time.deltaTime * 3;
        }

        move.z = speed;
        move += gravity;
        move *= Time.deltaTime;

        float input = Input.GetAxis("Horizontal");

        if (Mathf.Abs(input) > .1f)
        {
            if (!changeFrame)
            {
                changeFrame = true;
                laneNumber -= (int)Mathf.Sign(input);
                laneNumber = Mathf.Clamp(laneNumber, 0, laneCount);
            }
        }
        else
        {
            changeFrame = false;
        }

        characterController.Move(move);

        Vector3 newPos = transform.position;
        newPos.x = Mathf.Lerp(newPos.x, firstLanePos + (laneNumber * lastLanePos), Time.deltaTime * sideSpeed);
        transform.position = newPos;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        ITrigger trigger = hit.gameObject.GetComponent<ITrigger>();

        if (trigger is Money)
        {
            Money money = trigger as Money;
            money.Collect();
            onMoneyCollect?.Invoke(money.Count);
        }

        if (hit.gameObject.tag == "Tile")
            GameController.isRun = false;

        //GameController.isRun = false;
    }
}
