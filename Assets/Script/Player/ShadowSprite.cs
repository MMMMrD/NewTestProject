using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    //MMMMrD��ӣ�����ؽű���Ҫ ����֪����ʲ���Ƿ��w���Ϳ�һ�°ɣ�
    [Header("λ�Å���")]
    private Transform userTransform;  //ʹ����λ��

    [Header("ʱ����Ʋ���")]
    public float activeTime;
    public float activeStart;

    [Header("��͸���ȿ���")]
    public float alphaSet;
    public float alphaMultiplier;
    private float alpha;
    private SpriteRenderer userSpriteRenderer;  //ʹ���ߵ�SpriteRenderer

    protected void OnEnable()
    {
        //TODO����Ҫ�޸�Playerʹ��Ӱ�ӵ�߉݋
        // player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        // playerSprite = player.GetComponent<SpriteRenderer>();
        if (userSpriteRenderer != null)
        {
            alpha = alphaSet;
            thisSprite.sprite = userSpriteRenderer.sprite;
            transform.position = userTransform.position;
            transform.localScale = userTransform.localScale;
            transform.rotation = userTransform.rotation;
            activeStart = Time.time;
        }



    }

    protected void Update()
    {
        alpha *= alphaMultiplier;

        color = new Color(1, 1, 1, alpha);

        thisSprite.color = color;

        if (Time.time >= activeStart + activeTime)
        {
            ObjectPool.Instance.PushObject(this.gameObject);
        }
    }

    //TODO����������Ż�ShadowSprite��ʹ�����н�ɫ������ʹ��
    //MMMMrD��ӣ����߽ű���Ҫ
    public void Init(Transform transform, SpriteRenderer spriteRenderer)
    {
        userTransform = transform;
        userSpriteRenderer = spriteRenderer;
        Debug.Log(userTransform);
        Debug.Log(userSpriteRenderer);
    }
}
