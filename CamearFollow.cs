using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamearFollow : MonoBehaviour
{
    private Transform PlayerTarget;

    private float smoothSpeed=2f;
    [SerializeField]
    private float playerBoundMin_Y = -1f, playerBoundMin_X=-65, playerBoundMan_X=65;
    [SerializeField]
    private float Gap_Y = 2f;
    private Vector3 tempos;
    private void Start()
    {
        PlayerTarget = GameObject.FindWithTag(Tag.player_TAG).transform;
    }
    private void Update()
    {
        if (!PlayerTarget)
            return;
        tempos = transform.position;
        if (PlayerTarget.position.y <= playerBoundMin_Y)
        {
            tempos = Vector3.Lerp(transform.position,new Vector3(PlayerTarget.position.x,
                PlayerTarget.position.y,-10f),Time.deltaTime*smoothSpeed);
        }
        else
        {
            tempos = Vector3.Lerp(transform.position, new Vector3(PlayerTarget.position.x,
    PlayerTarget.position.y+ Gap_Y, -10f), Time.deltaTime * smoothSpeed);

        }
        if (tempos.x < playerBoundMan_X)
            tempos.x = playerBoundMan_X;
        if (tempos.x<playerBoundMin_X)
            tempos.x = playerBoundMin_X;


        transform.position = tempos;
    }


}
