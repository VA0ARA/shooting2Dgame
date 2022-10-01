using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShotingManager : MonoBehaviour
{
    [SerializeField]
    private GameObject BulletPrefabs;
    [SerializeField]
    private Transform bulletSpawnpos;
    public void Shoot(float facingDirection)
    {
        GameObject NewBullet = Instantiate(BulletPrefabs, bulletSpawnpos.position, Quaternion.identity);
        if (facingDirection < 0)
        {
            NewBullet.GetComponent<Bullet>().SetNegtiveSpeed();

        }
    }

}//class
