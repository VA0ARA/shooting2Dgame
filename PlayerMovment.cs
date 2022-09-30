using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 3.5f;
    // bounder this movment remove gravity in rigidbody
    [SerializeField]
    private float minBound_X = -9.55f, maxBound_X = 63.79f, minBound_Y =-3.09f, maxBound_Y =-1f;
    Vector3 tempos;
    private float xAxis, yAxis;
    private PlayerAnimation playeranimation;
    [SerializeField]
    private float ShootWaitTime = 1f;
    private float WaitBeforShooting;
    [SerializeField]
    private float MoveWaitTime;
    private float waitbeformoving;
    private bool CanMove=true;

    private void Awake()
    {
        playeranimation = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        HandelMovment();
        HandelAnimation();
        HandelFacingDirection();

        handelShooting();
        CheckIfCanMove();



    }
    void HandelMovment()
    {
        xAxis = Input.GetAxisRaw(Tag.HORIZENTAL_AXIS);
        yAxis = Input.GetAxisRaw(Tag.VERTICAL_aXIS);
        if (!CanMove)
            return;
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
        

    }
    void HandelAnimation()
    {
        if (!CanMove)
            return;
        if (Mathf.Abs(xAxis) > 0 || Mathf.Abs(yAxis) > 0)
            playeranimation.PlayAnimation(Tag.WALK_ANIMATION_NAME);
        else
            playeranimation.PlayAnimation(Tag.IDEL_ANIMATION_NAME);

    }
    public void HandelFacingDirection()
    {
        if (xAxis > 0)
        {
            playeranimation.SetFacingDirection(true);

        }else if (xAxis < 0)
        {
            playeranimation.SetFacingDirection(false);
        }

    }
    void StopMOvement()
    {
        CanMove = false;
        waitbeformoving = Time.time + MoveWaitTime;

    }
    void Shoot()
    {
        WaitBeforShooting = Time.time + ShootWaitTime;
        StopMOvement();
        playeranimation.PlayAnimation(Tag.SHOOT_ANIMATION_NAME);
    }
    void CheckIfCanMove()
    {
        if (Time.time > waitbeformoving)
            CanMove = true;
    }
    void handelShooting()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            
            if (Time.time > WaitBeforShooting)
                Shoot();
        }

    }
}
