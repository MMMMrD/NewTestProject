using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour, IDamageable
{
    public enum SkeletonEnum
    {
        Call, Idle, Attack1, Patrol
    }

    private Dictionary<SkeletonEnum, SkeletonBaseState> states = new Dictionary<SkeletonEnum, SkeletonBaseState>();
    private SkeletonBaseState currentState;


    private void Awake()
    {
        //states.Add()
    }
    // Start is called before the first frame update
    void Start()
    {

    }


    void Update()
    {
        //currentState.UpdateState();
    }

    /// <summary>
    /// �л�״̬ΪĿ��״̬
    /// </summary>
    /// <param name="type">��Ҫ�л���״̬ö����</param>
    public void SwitchState(SkeletonEnum type)
    {
        currentState = states[type];
        currentState.EnterState();
    }




    public void GetHit(float damage)
    {
    }
}
