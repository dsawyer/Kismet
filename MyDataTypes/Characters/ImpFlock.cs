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

    class ImpFlock: Enemy
    {
        public static List<Vector2[]> patternList = new List<Vector2[]>();

        Vector2[] PlusPattern = new Vector2[]
        {
            new Vector2(2,2),
            new Vector2(3,2),
            new Vector2(1,2),
            new Vector2(2,1),
            new Vector2(2,3)
        };
        Vector2[] ArrowPatternRight = new Vector2[]
        {
            //column/row
            new Vector2(0,2),
            new Vector2(1,3),
            new Vector2(3,3),
            new Vector2(2,4),
            new Vector2(4,2),
        };
        Vector2[] ArrowPatternLeft = new Vector2[]
        {
            //column/row
            new Vector2(2,0),
            new Vector2(0,2),
            new Vector2(3,1),
            new Vector2(4,2),
            new Vector2(1,1),
        };
        Vector2[] LinePattern = new Vector2[]
        {
            //column/row
            new Vector2(2,0),
            new Vector2(2,1),
            new Vector2(2,2),
            new Vector2(2,3),
            new Vector2(2,4),
        };
        Vector2[] AttackPattern1 = new Vector2[]
        {
            //column/row
            new Vector2(4,0),
            new Vector2(3,1),
            new Vector2(2,2),
            new Vector2(3,3),
            new Vector2(4,4),
        };

        
        public  List<Imp> flockList = new List<Imp>();
        /// <summary>
        /// Gets and Sets the status of the Enemy object 
        /// </summary>
        public List<Imp> FlockList { get { return flockList; } set { flockList = value; } }

        // A. 2D array of strings.
        Vector2[,] PatternMap = new Vector2[,]
	    {
	        {new Vector2(-100,-100), new Vector2(-50,-100), new Vector2(0,-100), new Vector2(50,-100), new Vector2(100,-50) },
	        {new Vector2(-100,-50), new Vector2(-50,-50), new Vector2(0,-50), new Vector2(50,-50), new Vector2(100,-50) },
            {new Vector2(-100,  0), new Vector2(-50,  0), new Vector2(0,  0), new Vector2(50,  0), new Vector2(100,  0) },
            {new Vector2(-100, 50), new Vector2(-50, 50), new Vector2(0, 50), new Vector2(50, 50), new Vector2(100, 50) },
            {new Vector2(-100, 100), new Vector2(-50, 100), new Vector2(0, 100), new Vector2(50, 100), new Vector2(100, 100) },
	    };

        private float time;
        private float attackTime;
        private int currentPattern;
        private Vector2 returnPosition;
        public Vector2 ReturnPosition { get { return returnPosition; } set { returnPosition = value; } }
        public bool playerLight = false;
        /// <summary>
        /// Constructors a new sprite.
        /// </summary>        
        public ImpFlock(ContentManager p_Content, string p_XMLFile, Vector2 p_InitialPosition)
        {
            Direction = GV.LEFT;
            IsAlive = true;
            returnPosition = p_InitialPosition;
            Position = p_InitialPosition;
            patternList.Add(PlusPattern);
            patternList.Add(ArrowPatternRight);
            patternList.Add(ArrowPatternLeft);
            patternList.Add(AttackPattern1);
            currentPattern = 0;
            time = 0;
            for (int i = 0; i <5; i++)
            {
                Imp newImp = new Imp(GV.ContentManager, "XML Documents/ImpAnimations", p_InitialPosition);
                newImp.FlockPosition = i;
                flockList.Add(newImp);
            }
            State = new FlockPatrolState(this);
            StateMachine = new StateMachine(this, new FlockPatrolState(this));
            StateMachine.AddState("KismetDataTypes.FlockPatrolState", "", "FlockPatrolState");
            StateMachine.AddState("KismetDataTypes.FlockPatrolState", "insight", "FlockAttackState");
            StateMachine.AddState("KismetDataTypes.FlockAttackState", "", "FlockAttackState");
            StateMachine.AddState("KismetDataTypes.FlockAttackState", "insight", "FlockAttackState");
        }


        /// <summary>
        /// updates each imp in the flock.
        /// </summary>
        /// <param name="p_GameTime"></param>
        public override void Update(GameTime gameTime)
        {
            State.Update(gameTime);
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            SightDetected = false;
            if (flockList.Count > 0)
            {
                float minDistance = 0;
                int index = 0;

                if (MagicItemManager.lightCount > 0)
                {
                    Vector2[] lightSpells = MagicItemManager.GetLightMagicArray(MagicItemManager.lightCount);

                    // Since the camera's position is removed from the light magic's position
                    // when returning the array of positions (makes it easier for the shader),
                    // it needs to be added back in for calculating the position in the world.
                    //
                    // Check all the lights for moving them close to a nearby light source
                    for (int i = 0; i < MagicItemManager.lightCount; i += 1)
                    {
                        float diffx = lightSpells[i].X - Position.X;
                        float diffy = lightSpells[i].Y - Position.Y;
                        float distance = (float)Math.Sqrt((diffx * diffx) + (diffy * diffy));
                        // Get the distances between the imps and the light sources, comparing
                        // each time to find the closest one and its index in the array
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            index = i;
                        }
                        else if (minDistance == 0)
                        {
                            minDistance = distance;
                            index = i;
                        }
                    }
                    // Set the new values for the flock's base location
                    ReturnPosition = lightSpells[index];
                    // Sets the flock's current position to be around the light
                    Position = lightSpells[index];
                }
                else // Go into the lights that are a part of the level
                {
                    for (int i = 0; i < GV.Level.NumLights; i += 1)
                    {
                        float diffx = GV.Level.Lights[i].Centre.X - Position.X;
                        float diffy = GV.Level.Lights[i].Centre.Y - Position.Y;
                        float distance = (float)Math.Sqrt((diffx * diffx) + (diffy * diffy));
                        // Get the distances between the imps and the light sources, comparing
                        // each time to find the closest one and its index in the array
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            index = i;
                        }
                        else if (minDistance == 0)
                        {
                            minDistance = distance;
                            index = i;
                        }
                    }

                    // Set the new base position foor the flock
                    ReturnPosition = GV.Level.Lights[index].Centre;
                }

                float distanceX = Math.Abs(ReturnPosition.X - Position.X);
                if (distanceX > 15 && !playerLight)
                {
                    // Sets the current position if the imps have strayed too far from a light
                    Position = ReturnPosition;
                }

                for (int i = 0; i < flockList.Count; i++) // Loop through List with for each item in list
                {
                    Imp imp = flockList[i];
                    if (!imp.IsAlive)
                    {
                        flockList.Remove(imp);
                    }
                    else
                    {
                        float radius = GV.Player.LightRadius;
                        Vector2 PlayerPosition = new Vector2(GV.Player.Position.X, GV.Player.Position.Y - (((float)GV.Player.Sprite.BoundingBox.Bottom - (float)GV.Player.Sprite.BoundingBox.Top)) / 2);
                        Vector2 impPosition = new Vector2(imp.Position.X, imp.Position.Y - (((float)imp.Sprite.BoundingBox.Bottom - (float)imp.Sprite.BoundingBox.Top)) / 2);
                        // check to see if there is a collision
                        float diffx = PlayerPosition.X - impPosition.X;
                        float diffy = impPosition.Y - PlayerPosition.Y;
                            
                        double diffRadius = Math.Sqrt(Math.Pow((double)diffx, 2) + Math.Pow((double)diffy, 2));
                            
                        if (diffRadius <= radius)
                        {
                            if (diffx < 0)
                                imp.Direction = GV.LEFT;
                            else
                                imp.Direction = GV.RIGHT;

                            SightDetected = true;
                        }
                            
                        if (time >= 2.0f)
                        {
                            currentPattern = (currentPattern + 1) % 3;
                            time = 0.0f;
                        }

                        if (State.GetType().ToString() == "KismetDataTypes.FlockAttackState")
                        {
                            currentPattern = 3;
                        }
                               
                                                       
                        Vector2 patternPosition = patternList[currentPattern][i];
                        Vector2 flockPosition = PatternMap[(int)patternPosition.X, (int)patternPosition.Y];
                        //Vector2 patternPosition = patternList[1][i];
                          
                        Vector2 worldPosition = Position + flockPosition;
                        imp.Position += (worldPosition - imp.Position) / 40;
                        imp.Velocity = Velocity;
                        imp.Update(gameTime);
                    }

                }
                    
                Position += Velocity;
                
                //Console.WriteLine("insight " + SightDetected);
                //Console.WriteLine("state " + State.GetType().ToString());
                if (SightDetected)
                {
                    //Console.WriteLine("insight " + SightDetected);
                    attackTime = 0;
                    //StateMachine.UpdateState("insight");
                    //returnPosition = Position;
                    State = new FlockAttackState(this);
                    SightDetected = true;
                    //Console.WriteLine("  switch to attack state");
                }
                else if (!SightDetected && State.GetType().ToString() == "KismetDataTypes.FlockAttackState")
                {
                    //Position = new Vector2(returnPosition.X, returnPosition.Y);
                    State = new FlockPatrolState(this);
                    //Console.WriteLine("  switch to patrol state");
                }


            }
            else
            {
                IsAlive = false;
            }

        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Imp imp in flockList) // Loop through List with foreach
            {
                imp.Draw(gameTime, spriteBatch);
            }
        }
    }
}
