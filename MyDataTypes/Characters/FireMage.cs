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
    class FireMage : Enemy
    {
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public FireMage(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {

            Sprite = new Sprite(p_Content, p_XMLFile);
            Sprite.Scale = 1.0f;
            State = new PatrolState(this);
            Direction = GV.RIGHT;
            Velocity = new Vector2(0, 0);

            Position = p_InitialPosition;
            IsAlive = true;
            Health = 50;

            IsOnGround = false;



            StateMachine = new StateMachine(this, new PatrolState(this));

            StateMachine.AddState("KismetDataTypes.PatrolState", "insight", "PursueState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "jump", "EnemyJumpingState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.EnemyJumpingState", "", "PatrolState");
            StateMachine.AddState("KismetDataTypes.EnemyJumpingState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.PursueState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.PursueState", "noCollision", "PatrolState");
            StateMachine.AddState("KismetDataTypes.PursueState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.KnockedDownState", "", "PatrolState");

            StateMachine.AddState("KismetDataTypes.AttackState", "", "PatrolState");
            StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "KnockedDownState");

        }
    }
}
