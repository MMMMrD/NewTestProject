﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assassin_Cultist_State
{
    public class RunState : ChildStateMachine
    {
        public override void EnterState(Boss boss)
        {
            boss.anim.SetBool("Run", true);
        }

        public override void UpdateState(Boss boss)
        {
            if(Mathf.Abs(boss.target.position.x - boss.transform.position.x) > 0.1f)
            {
                boss.Movement();
            }
            else
            {
                //转换为站立形态
                ExitState(boss);
                boss.currentParentState.TransitionChildState(boss.currentParentState.idleState, boss);
            }
        }

        public override void ExitState(Boss boss)
        {
            boss.anim.SetBool("Run", false);
        }
    }
    
}

