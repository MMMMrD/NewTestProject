using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float speed;
    public float interval;//������ʱ��
    public GameObject bulletPrefab;//�ӵ�Ԥ����
    public GameObject shellPrefab;//����Ԥ����
    protected Transform muzzlePos;//ǹ��λ��
    protected Transform shellPos;//����λ��
    protected Vector2 mousePos;//���λ��
    protected Vector2 direction;//���䷽��
    public Color color;//�ӵ���ɫ
    protected float timer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        shellPos = muzzlePos = transform.GetComponentInParent<Transform>();
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Shoot();
    }

    protected virtual void Shoot()
    {
        direction = (mousePos - new Vector2(transform.position.x, transform.position.y)).normalized;
        //direction = (mousePos - new Vector2(transform.position.x, transform.position.y));

        if (timer != 0)
        {
            timer -= Time.deltaTime;
            if (timer <= 0) timer = 0;
        }

        if (Input.GetButton("Fire1"))
        {
            if (timer == 0)
            {
                timer = interval;
                Fire();
            }
        }
    }

    protected virtual void Fire()
    {
        GameObject bullet = ObjectPool.Instance.GetObject(bulletPrefab);
        bullet.transform.position = muzzlePos.position;

        float angel = Random.Range(-3f, 3f);
        bullet.GetComponent<Bullet>().SetSpeed(Quaternion.AngleAxis(angel, Vector3.forward) * direction, speed);
        bullet.GetComponent<Bullet>().SetColor(color);

        GameObject shell = ObjectPool.Instance.GetObject(shellPrefab);
        shell.transform.position = shellPos.position;
        shell.transform.rotation = shellPos.rotation;
    }

}
