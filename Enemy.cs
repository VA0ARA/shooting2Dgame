using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform PlayerTarget;
    [SerializeField]
    private float MOveSpeed = 2f;
    private Vector3 tempScale;
    [SerializeField]
    private float stoppingDistance = 1.5f;
    private PlayerAnimation enemyanimation;
    [SerializeField]
    private float AttackWaittime=2.5f;
    private float AttackTimer;
    [SerializeField]
    private float AttackFinishedWaitTime=0.5f;
    private float AttackFinishTimer;
    [SerializeField]
    private EnemyDamageArea enemyDamageArea;
    private void Awake()
    {
        PlayerTarget = GameObject.FindWithTag(Tag.player_TAG).transform;
        enemyanimation = GetComponent<PlayerAnimation>();
    }
    private void Update()
    {
        SearchforPlayer();


    }
    void SearchforPlayer()
    {
        if (!PlayerTarget)
            return;
        if (Vector3.Distance(transform.position, PlayerTarget.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, PlayerTarget.position,
                MOveSpeed * Time.deltaTime);
            enemyanimation.PlayAnimation(Tag.WALK_ANIMATION_NAME);
            HandelFacingDirection();
        }
        else
        {
            CheckIfatackFinished();
            Attack();

        }
    }
    void HandelFacingDirection()
    {
        tempScale = transform.localScale;
        if (transform.position.x > PlayerTarget.position.x)
        {
            tempScale.x = -Mathf.Abs(tempScale.x);
        }
        else
        {
            tempScale.x = Mathf.Abs(tempScale.x);
        }
        transform.localScale = tempScale;
         
    }
    void CheckIfatackFinished()
    {
        if (Time.time > AttackTimer)
        {
            enemyanimation.PlayAnimation(Tag.IDEL_ANIMATION_NAME);
        }

    }
    void Attack()
    {
        if (Time.time > AttackTimer)
        {
            AttackFinishTimer = Time.time + AttackFinishedWaitTime;
            AttackTimer = Time.time + AttackWaittime;

            enemyanimation.PlayAnimation(Tag.ATTACK_ANIMATION_NAME);
        }

    }
    void EnemyAtacked()
    {
        enemyDamageArea.gameObject.SetActive(true);
        enemyDamageArea.ReasetDeativeTimer();
    }





}//class
