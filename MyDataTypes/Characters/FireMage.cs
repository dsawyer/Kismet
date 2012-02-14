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

            State = new EnemyIdleState(this);
            Direction = GV.LEFT;
            Velocity = new Vector2(0, 0);

            Position = p_InitialPosition;
            IsAlive = true;
            IsOnGround = false;
            

            StateMachine = new StateMachine(this, new EnemyIdleState(this));

            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.EnemyIdleState", "isHit", "EnemyIdleState");
            StateMachine.AddState("KismetDataTypes.AttackState", "collision", "EnemyIdleState");
            StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "EnemyIdleState");
            StateMachine.AddState("KismetDataTypes.AttackState", "", "EnemyIdleState");

        }
    }
}
