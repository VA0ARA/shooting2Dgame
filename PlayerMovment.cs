using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3.5f;
    // bounder this movment
    [SerializeField]
    private float minBound_X = -9.55f, maxBound_X = 63.79f, minBound_Y =-3.09f, maxBound_Y =-1f;
    Vector3 tempos;
    private float xAxis, yAxis;

    void Update()
    {
        HandelMovment();
       
        
    }
    void HandelMovment()
    {
        xAxis = Input.GetAxisRaw(Tag.HORIZENTAL_AXIS);
        yAxis = Input.GetAxisRaw(Tag.VERTICAL_aXIS);
        tempos = transform.position;
        tempos.x += xAxis * MoveSpeed * Time.deltaTime;
        tempos.y += yAxis * MoveSpeed * Time.deltaTime;
        if (tempos.x < minBound_X)
            tempos.x = minBound_X;
        if (tempos.x > maxBound_X)
            tempos.x = maxBound_X;
        if (tempos.y > maxBound_Y)
            tempos.y = maxBound_Y;
        if (tempos.y < minBound_Y)
            tempos.y = minBound_Y;
        transform.position = tempos;
        Debug.Log("starrt");

    }
}
