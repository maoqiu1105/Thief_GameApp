using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;

namespace Thief
{
    //made by Kevin
    class Coin : DrawableGameComponent
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private List<Rectangle> coinFrams;
        private Random random = new Random();

        //coin 1,2,3
       public static Rectangle coin1, coin2, coin3;

        //coins array
        public static Rectangle[] coins = new Rectangle[5];

        //spin the coins
        float time;
        float timeFrame = 0.1f;
        SoundEffect coinSound;
        Texture2D coinFrame;

        const int GAMEPIXEL = 30;
        int currentFrame = 0;

        public Coin(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;

            //add three coins and set their position
            coin1 = new Rectangle(random.Next(0,800),0, GAMEPIXEL, GAMEPIXEL);
            coin2 = new Rectangle(random.Next(0, 800), 0, GAMEPIXEL, GAMEPIXEL);
            coin3 = new Rectangle(random.Next(0, 800), 0, GAMEPIXEL, GAMEPIXEL);

            for (int i = 0; i < coins.Length; i++)
            {
                coins[i] = new Rectangle(random.Next(0, 800), 0, GAMEPIXEL, GAMEPIXEL);
            }
            //get the fram work from source image
            coinFrams = new List<Rectangle>();
            coinFrams.Add(new Rectangle(67, 59, 133, 135));
            coinFrams.Add(new Rectangle(235, 59, 119, 135));
            coinFrams.Add(new Rectangle(416, 59, 74, 135));
            coinFrams.Add(new Rectangle(591, 59, 46, 135));

            LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            //the coin spin each 0.1s
            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (time > timeFrame)
            {
                currentFrame++;
                time = 0f;
                if (currentFrame > 3)
                {
                    currentFrame = 0;
                }
            }

            //coins fall down speed
            coin1.Y += random.Next(2, 4);
            coin2.Y += random.Next(2, 4);
            coin3.Y += random.Next(2, 4);

            //coins reset when it disapper at buttom
            if (coin1.Y >= 340)
            {
                coin1.Y = 0;
                coin1.X = random.Next(0, 800);
            }
            if (coin2.Y >= 340)
            {
                coin2.Y = 0;
                coin2.X = random.Next(0, 800);
            }
            if (coin3.Y >= 340)
            {
                coin3.Y = 0;
                coin3.X = random.Next(0, 800);
            }


            //coins reset when it touch the player
            if (coin1.Intersects(Player.player))
            {
                coinSound.Play();
                Score.nScore ++;
                coin1.Y = 0;
                coin1.X = random.Next(0, 800);
            }
            if (coin2.Intersects(Player.player))
            {
                coinSound.Play();
                Score.nScore++;
                coin2.Y = 0;
                coin2.X = random.Next(0, 800);
            }
            if (coin3.Intersects(Player.player))
            {
                coinSound.Play();
                Score.nScore++;
                coin3.Y = 0;
                coin3.X = random.Next(0, 800);
            }

            //rest the coin2 when two or more coins intersect
            if(coin1.Intersects(coin2) || coin1.Intersects(coin3) || coin2.Intersects(coin3))
            {
                coin2.Y = 0;
                coin2.X = random.Next(0, 800);
            }


            //coins array reset and get score
            for (int i = 0; i < coins.Length; i++)
            {
                coins[i].Y += random.Next(2,5);
                if (coins[i].Y > 340)
                {
                    coins[i].Y = 0;
                    coins[i].X = random.Next(0, 800);
                }

                if (coins[i].Intersects(Player.player))
                {
                    coinSound.Play();
                    coins[i].Y = 0;
                    coins[i].X = random.Next(0, 800);
                    Score.nScore++;
                }
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            //load coin image
            coinFrame = content.Load<Texture2D>("coin");

            //load coin sound
            coinSound = content.Load<SoundEffect>("coinsound");
            base.LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            //draw the coins
            spriteBatch.Begin();
            spriteBatch.Draw(coinFrame, coin1, coinFrams.ElementAt<Rectangle>(currentFrame), Color.White);
            spriteBatch.Draw(coinFrame, coin2, coinFrams.ElementAt<Rectangle>(currentFrame), Color.White);
            spriteBatch.Draw(coinFrame, coin3, coinFrams.ElementAt<Rectangle>(currentFrame), Color.White);

            //draw coins array
            for (int i = 0; i < coins.Length; i++)
            {
                spriteBatch.Draw(coinFrame, coins[i], coinFrams.ElementAt<Rectangle>(currentFrame), Color.White);
            }
            spriteBatch.End();

        }
    }
}
