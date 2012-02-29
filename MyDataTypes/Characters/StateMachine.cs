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

    public class StateMachine
    {
        private Dictionary<string, string> stateMachine = new Dictionary<string, string>();
        private Enemy enemy;
        // Properties
        public Enemy Enemy
        {
            get { return enemy; }
        }

        /// <summary>
        ///Constructor 
        /// </summary>
        /// <param name="p_Object"></param>
        public StateMachine(Enemy p_Enemy, EnemyState enemyState)
        {
            enemy = p_Enemy;
            enemy.State = enemyState;
        }

        public void UpdateState(string p_Input)
        {
            string key = "" + Enemy.State + p_Input;

            ChangeState(stateMachine[key]);

        }

        public void AddState(string currentState, string input, string nextState)
        {
            string key = "" + currentState + input;
            stateMachine.Add(key, nextState);
        }

        public void ChangeState(string nextState)
        {
            switch (nextState)
            {
                case "EnemyIdleState":
                    Enemy.State = new EnemyIdleState(Enemy);
                    break;
                case "AwakeState":
                    Enemy.State = new AwakeState(Enemy);
                    break;
                case "PatrolState":
                    Enemy.State = new PatrolState(Enemy);
                    break;
                case "PursueState":
                    Enemy.State = new PursueState(Enemy);
                    break;
                case "AttackState":
                    Enemy.State = new AttackState(Enemy);
                    break;
                case "EnemyJumpingState":
                    Enemy.State = new EnemyJumpingState(Enemy);
                    break;
                case "KnockedDownState":
                    Enemy.State = new KnockedDownState(Enemy);
                    break;
                case "TeleportState":
                    Enemy.State = new TeleportState(Enemy);
                    break;
                case "FlyState":
                    Enemy.State = new FlyState(Enemy);
                    break;
                case "FlockPatrolStateState":
                    Enemy.State = new FlockPatrolState(Enemy);
                    break;


                default:
                    Console.WriteLine("Invalid selection");
                    break;
            }

        }
        
    }
}


/* private Dictionary<Key, EnemyState> stateMachine = new Dictionary<Key, EnemyState>();
        private Enemy enemy;

        // Properties
        public Enemy Enemy
        {
            get { return enemy; }
        }
     
        /// <summary>
        ///Constructor 
        /// </summary>
        /// <param name="p_Object"></param>
        public StateMachine(Enemy p_Enemy, EnemyState enemyState)
        {
             enemy = p_Enemy;
            enemy.State = enemyState;
        }

       




        public void UpdateState(string p_Input)
        {
            Key queryKey = new Key(Enemy.State, p_Input);
            EnemyState newEnemyState = stateMachine[queryKey];
            Enemy.State = newEnemyState;
             
        }

        public void AddState(EnemyState currentState, string input, EnemyState nextState)
        {
            Key newkey = new Key(currentState,input);
            stateMachine.Add(newkey, nextState);
        }
*/