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
    public static class RewardManager
    {

        public static List<Reward> rewardList = new List<Reward>();
        public static void AddReward(string p_Type, int p_Amount, Vector2 p_Point)
        {
            rewardList.Add(new Reward(p_Type, p_Amount, p_Point));
        }

        public static void Update(GameTime gameTime)
        {
            if (rewardList.Count > 0)
            {
                for (int i = 0; i < rewardList.Count; i++) // Loop through List with for each item in list
                {
                    Reward reward = rewardList[i];
                    if (!reward.Active)
                    {
                        rewardList.Remove(reward);

                    }
                    else
                    {
                        reward.Update(gameTime);
                    }

                }
            }
        }

        public static void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            foreach (Reward reward in rewardList) // Loop through List with foreach
            {
                reward.Draw(gameTime, spriteBatch);
            }
        }

    }
}
