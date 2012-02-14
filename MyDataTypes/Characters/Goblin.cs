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
    class Goblin: Enemy
    {
       /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Goblin(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {   

            Sprite = new Sprite(p_Content, p_XMLFile);

            State = new AwakeState(this);
            Direction = GV.LEFT;
            Velocity = new Vector2(0, 0);

            PositionInTile(p_InitialPosition);
            IsAlive = true;
            Health = 100;
            IsOnGround = false;


            StateMachine = new StateMachine(this, new AwakeState(this));

            StateMachine.AddState("KismetDataTypes.AwakeState", "", "PatrolState");

            StateMachine.AddState("KismetDataTypes.PatrolState", "collision", "PursueState");
            StateMachine.AddState("KismetDataTypes.PatrolState", "isHit", "KnockedDownState");


            StateMachine.AddState("KismetDataTypes.PursueState", "collision", "AttackState");
            StateMachine.AddState("KismetDataTypes.PursueState", "noCollision", "PatrolState");
            StateMachine.AddState("KismetDataTypes.PursueState", "isHit", "KnockedDownState");

            StateMachine.AddState("KismetDataTypes.KnockedDownState", "", "PatrolState");

            StateMachine.AddState("KismetDataTypes.AttackState", "", "PatrolState");
            StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "KnockedDownState");

                     
        }
    }
}
