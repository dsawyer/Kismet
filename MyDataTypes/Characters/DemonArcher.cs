using System;
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
    class DemonArcher : Enemy
    {
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public DemonArcher(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {

            Sprite = new Sprite(p_Content, p_XMLFile);
            Sprite.Scale = 1.0f;
            State = new EnemyIdleState(this);
            Direction = GV.RIGHT;
            Velocity = new Vector2(0, 0);

            Position = p_InitialPosition;
            IsAlive = true;
            Health = 50;

            IsOnGround = false;



            StateMachine = new StateMachine(this, new EnemyIdleState(this));

            StateMachine.AddState("KismetDataTypes.PatrolState", "insight", "AttackState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.PatrolState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "isHit", "KnockedDownState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "jump", "AttackState");

            StateMachine.AddState("KismetDataTypes.PursueState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.PursueState", "noCollision", "EnemyIdleState");
            StateMachine.AddState("KismetDataTypes.PursueState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.KnockedDownState", "", "EnemyIdleState");

            StateMachine.AddState("KismetDataTypes.AttackState", "", "EnemyIdleState");
            StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "KnockedDownState");


        }
    }
}
