﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace KismetDataTypes
{
    class MiniBoss : Enemy
    {
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public MiniBoss(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {

            Sprite = new Sprite(p_Content, p_XMLFile);
            Sprite.Scale = 1.0f;
            State = new EnemyIdleState(this);
            AnimationReversed = true;
            Direction = GV.LEFT;
            Velocity = new Vector2(0, 0);
            //PositionInTile(p_InitialPosition);
            Position = p_InitialPosition;
            IsAlive = true;
            Health = 1000;
            IsOnGround = false;
            //Position = p_InitialPosition;


           
            StateMachine = new StateMachine(this, new EnemyIdleState(this));

            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "collision", "PatrolState");
           // StateMachine.AddState("KismetDataTypes.EnemyIdleState", "isHit", "KnockedDownState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "isHit", "TeleportState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "insight", "AttackState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "teleport", "TeleportState");

            StateMachine.AddState("KismetDataTypes.PatrolState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "isHit", "KnockedDownState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "insight", "AttackState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "jump", "TeleportState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "idle", "EnemyIdleState");

            StateMachine.AddState("KismetDataTypes.PursueState", "collision", "TeleportState");
            StateMachine.AddState("KismetDataTypes.PursueState", "noCollision", "PatrolState");

            StateMachine.AddState("KismetDataTypes.PursueState", "isHit", "AttackState");

            StateMachine.AddState("KismetDataTypes.KnockedDownState", "", "TeleportState");
            StateMachine.AddState("KismetDataTypes.TeleportState", "", "AttackState");
            StateMachine.AddState("KismetDataTypes.TeleportState", "isHit", "KnockedDownState");


            StateMachine.AddState("KismetDataTypes.AttackState", "", "PatrolState");
            StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "KnockedDownState");



        }
    }
}
