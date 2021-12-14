using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 3.5f;
    [SerializeField]
    private float minBoundX = -71, maxBoundX = 71, minBoundY = -3.3f, maxBoundY = 0;
    private float xAxis, yAxis;

    private PlayerAnimation playerAnimation;

    private Vector3 tempPos;

    private void Awake()
    {
        playerAnimation = GetComponent<PlayerAnimation>();    
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
        HandleAnimation();
        HandleFacingDirection();
    }

    void HandleMovement()
    {
        xAxis = Input.GetAxisRaw(TagManager.HORIZONTAL_AXIS);
        yAxis = Input.GetAxisRaw(TagManager.VERTICAL_AXIS);

        tempPos = transform.position;

        tempPos.x += xAxis * moveSpeed * Time.deltaTime;
        tempPos.y += yAxis * moveSpeed * Time.deltaTime;

        if (tempPos.x < minBoundX)
            tempPos.x = minBoundX;

        if (tempPos.x > maxBoundX)
            tempPos.x = maxBoundX;

        if (tempPos.y < minBoundY)
            tempPos.y = minBoundY;

        if (tempPos.y > maxBoundY)
            tempPos.y = maxBoundY;

        transform.position = tempPos;
    }

    void HandleAnimation()
    {
        if (Mathf.Abs(xAxis) > 0 || Mathf.Abs(yAxis) > 0)
            playerAnimation.PlayAnimation(TagManager.WALK_ANIMATION_NAME);
        else
            playerAnimation.PlayAnimation(TagManager.IDLE_ANIMATION_NAME);
    }

    void HandleFacingDirection()
    {
        if (xAxis > 0)
            playerAnimation.SetFacingDirection(true);
        else if (xAxis < 0)
            playerAnimation.SetFacingDirection(false);
    }
}
