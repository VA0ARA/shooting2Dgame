using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamageArea : MonoBehaviour
{
    private float DeactivateWaiteTime = 0.1f;
    private float DeactivTimer;

    [SerializeField]
    private LayerMask playerlayer;
    private bool CandealDamage;
    [SerializeField]
    private float DamageAmount=5f;

    private void Awake()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (Physics2D.OverlapCircle(transform.position, 1f, playerlayer))
        {
            if (CandealDamage)
            {
                CandealDamage = false;
                Debug.Log("Damage");
            }
        }
        DetectiveDamageArea();
    }
    void DetectiveDamageArea()
    {
        if (Time.time > DeactivTimer)
        {
            gameObject.SetActive(false);
        }
    }
    public void ReasetDeativeTimer()
    {
        CandealDamage = true;
        DeactivTimer = Time.time + DeactivateWaiteTime;
    }



}//class
