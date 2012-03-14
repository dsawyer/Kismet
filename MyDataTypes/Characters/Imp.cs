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
    class Imp : Enemy
    {

        private int flockPosition;
        public int FlockPosition { get { return flockPosition; } set { flockPosition = value; } }
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public Imp(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {
            
            Sprite = new Sprite(p_Content, p_XMLFile);
            Sprite.Scale = 1.0f;
            //State = new EnemyIdleState(this);
            Direction = GV.RIGHT;
            Velocity = new Vector2(0, 0);

            Position = p_InitialPosition;
            IsAlive = true;
            IsOnGround = false;
            Health = 20;

            StateMachine = new StateMachine(this, new FlyState(this));
            //StateMachine = new StateMachine(this, new EnemyIdleState(this));
            StateMachine.AddState("KismetDataTypes.KnockedDownState", "", "FlyState");
            //StateMachine.AddState("KismetDataTypes.EnemyIdleState", "isHit", "EnemyIdleState");
           // StateMachine.AddState("KismetDataTypes.AttackState", "collision", "EnemyIdleState");
           // StateMachine.AddState("KismetDataTypes.AttackState", "isHit", "EnemyIdleState");
           // StateMachine.AddState("KismetDataTypes.AttackState", "", "EnemyIdleState");

        }


        /// <summary>
        /// Handles input, and animates the player sprite.
        /// </summary>
        /// <param name="p_GameTime"></param>
        public override void Update(GameTime gameTime)
        {
            int health = Health;
            Vector2 nextPosition = Position + Velocity;
            State.Update(gameTime);
            Velocity = CollisionManager.ResolveCollisions(this, nextPosition, Velocity, MagicItemManager.GetList());
            //state.Update(gameTime);
            Position = Position + Velocity;
            //PreviousBottom = Position.Y;
            // state.Update(gameTime);

            //Console.WriteLine("" + Velocity.X + " " + Velocity.Y);

        }

    }
}
