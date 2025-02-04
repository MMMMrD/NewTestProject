using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPG : Gun
{
    public int roketNum;
    public float rocketAngel;


    protected override void Fire()
    {
        
        int median = roketNum / 2;

        for (int i = 0; i < roketNum; i++)
        {
            // GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
            // bullet.GetComponent<Bullet>().damage = damage;
            // bullet.GetComponent<Bullet>().SetColor(color);
            // bullet.transform.position = muzzlePos.position;

            if (roketNum % 2 == 1)
            {
                BulletFactory.Instance.CreatBullet("RPG", muzzlePos.position,
                Quaternion.AngleAxis(rocketAngel * (i - median), Vector3.forward) * direction, color, damage, mousePos, speed);
                // bullet.transform.right = Quaternion.AngleAxis(rocketAngel * (i - median), Vector3.forward) * direction;
            }
            else
            {
                BulletFactory.Instance.CreatBullet("RPG", muzzlePos.position,
                Quaternion.AngleAxis(rocketAngel * (i - median) + rocketAngel / 2, Vector3.forward) * direction, color, damage, mousePos, speed);
                // bullet.transform.right = Quaternion.AngleAxis(rocketAngel * (i - median) + rocketAngel / 2, Vector3.forward) * direction;
            }
            // bullet.GetComponent<Bullet>().SetTarget(mousePos);
        }
    }
}
