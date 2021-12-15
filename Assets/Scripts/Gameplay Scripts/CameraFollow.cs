using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform playerTarget;

    [SerializeField]
    private float smoothSpeed = 2f;
    [SerializeField]
    private float playerBoundMinY = -1, playerBoundMinX = -65, playerBoundMaxX = 65;
    [SerializeField]
    private float YGap = 2;

    private Vector3 tempPos;

    private void Start()
    {
        playerTarget = GameObject.FindWithTag(TagManager.PLAYER_TAG).transform;
    }

    private void Update()
    {
        if (!playerTarget)
            return;

        tempPos = transform.position;

        if(playerTarget.position.y <= playerBoundMinY)
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y, -10), Time.deltaTime * smoothSpeed);
        else
            tempPos = Vector3.Lerp(transform.position, new Vector3(playerTarget.position.x, playerTarget.position.y + YGap, -10), Time.deltaTime * smoothSpeed);

        if (tempPos.x > playerBoundMaxX)
            tempPos.x = playerBoundMaxX;

        if (tempPos.x < playerBoundMinX)
            tempPos.x = playerBoundMinX;

        transform.position = tempPos;
    }
}
