using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowSprite : MonoBehaviour
{
    private Transform player;
    private SpriteRenderer thisSprite;
    private SpriteRenderer playerSprite;

    private Color color;

    [Header("时间控制参数")]
    public float activeTime;
    public float activeStart;

    [Header("不透明度控制")]
    public float alphaSet;
    public float alphaMultiplier;
    private float alpha;

    protected void OnEnable()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        thisSprite = GetComponent<SpriteRenderer>();
        playerSprite = player.GetComponent<SpriteRenderer>();

        alpha = alphaSet;

        thisSprite.sprite = playerSprite.sprite;
        transform.position = player.position;
        transform.localScale = player.localScale;
        transform.rotation = player.rotation;

        activeStart = Time.time;
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

    //TODO：往后可以优化ShadowSprite，使得所有角色都可以使用
    //MMMMrD添加：忍者脚本需要
    public void Init(Transform transform, SpriteRenderer spriteRenderer){
        
    }
}
