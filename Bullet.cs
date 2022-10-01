using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float movespeed = 15f;
    [SerializeField]
    private float damageAmouny = 35f;
    private Vector3 MoveVector = Vector3.zero;
    private Vector3 tempScale;
    private void Start()
    {
        SetNegtiveSpeed();
    }

    private void Update()
    {
        MoveBullet();
    }
    void MoveBullet()
    {
        MoveVector.x = movespeed * Time.deltaTime;
        transform.position += MoveVector;

    }
    public void SetNegtiveSpeed()
    {
        movespeed *=-1;
        tempScale = transform.localScale;
        tempScale.x = -tempScale.x;
        transform.localScale = tempScale;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Tag.ENEMY_TAG))
        {
            //damage
        }

    }



}//class
