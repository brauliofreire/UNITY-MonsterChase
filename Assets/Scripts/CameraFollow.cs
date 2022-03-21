using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    private Transform playerTransf;
    private Vector3 tempPos;

    [SerializeField]
    private float minX, maxX;

    void Start()
    {
        var player = GameObject.FindWithTag("Player");
        if(player)
            playerTransf = player.transform;
    }

    void LateUpdate()
    {
        if (!playerTransf) return;

        tempPos = transform.position;        
        tempPos.x = playerTransf.position.x;

        if (tempPos.x < minX)
            tempPos.x = minX;

        if (tempPos.x > maxX)
            tempPos.x = maxX;

        transform.position = tempPos;
    }
}
