using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Thief
{
    //made by brad
    class Player : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Background background;
        ContentManager content;

        Texture2D spriteSheet;
        Texture2D spriteSheetRunning;
        List<Rectangle> goblinFrames;
        List<Rectangle> goblinFramesRunning;
        public static Rectangle player;
        
        private int isIdle = 0;
        private int isMovingLeft = 0;
        const int PIXWIDTH = 193;
        const int PIXHEIGHT = 272;
        const int SCALE = 4;
        // the elapsed amount of time the frame has been shown for
        float time;
        // duration of time to show each frame
        float frameTime = 0.1f;
        // an index of the current frame being shown
        int frameIndex;
        int frameIndexRunning;
        // total number of frames in our spritesheet
        const int TOTALFRAMES = 2;
        const int TOTALFRAMESRUNNING = 5;

        public Player(Game game, SpriteBatch spriteBatch, ContentManager content, Background background) : base(game)
        {
            this.background = background;
            this.spriteBatch = spriteBatch;
            this.content = content;

            //the player position in the beginning
            player = new Rectangle(5, 285, PIXWIDTH / SCALE, PIXHEIGHT / SCALE);

            //idle goblin fram 
            goblinFrames = new List<Rectangle>();
            goblinFrames.Add(new Rectangle(240, 271, PIXWIDTH, PIXHEIGHT));
            goblinFrames.Add(new Rectangle(903, 271, PIXWIDTH, PIXHEIGHT));
            goblinFrames.Add(new Rectangle(1578, 271, PIXWIDTH, PIXHEIGHT));

            //goblin running fram
            goblinFramesRunning = new List<Rectangle>();
            goblinFramesRunning.Add(new Rectangle(240, 271, PIXWIDTH, PIXHEIGHT));
            goblinFramesRunning.Add(new Rectangle(903, 271, PIXWIDTH, PIXHEIGHT));
            goblinFramesRunning.Add(new Rectangle(1578, 271, PIXWIDTH, PIXHEIGHT));
            goblinFramesRunning.Add(new Rectangle(2248, 271, PIXWIDTH, PIXHEIGHT));
            goblinFramesRunning.Add(new Rectangle(2917, 271, PIXWIDTH, PIXHEIGHT));
            goblinFramesRunning.Add(new Rectangle(3596, 271, PIXWIDTH, PIXHEIGHT));

            LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            KeyboardState keyState = Keyboard.GetState();
            //goblin is running
            if (keyState.IsKeyDown(Keys.Right) | keyState.IsKeyDown(Keys.Left))
            {
                isIdle = 0;
            }

            //goblin is idle
            else
            {
                isIdle = 1;
            }
                    
            //check the goblin is moving to right direction
            if (keyState.IsKeyDown(Keys.Right))
            {
                player.X += 4;
                isMovingLeft = 0;
            }
            else if (keyState.IsKeyDown(Keys.Left))
            {
                player.X -= 4;
                isMovingLeft = 1;
            }

            //check goblin is at the left boundary
            if (player.X < 0)
            {
                player.X = 0;
            }
            //check goblin is at the right boundary
            if (player.X > 750)
            {
                player.X = 750;
            }

            time += (float)gameTime.ElapsedGameTime.TotalSeconds;
            //turn the frame each 0.1s
            if (isIdle == 1)
            {
                while (time > frameTime)
                {
                    // Play the next frame in the SpriteSheet
                    frameIndex++;

                    // reset elapsed time
                    time = 0f;

                    //reset the idle goblin
                    if (frameIndex > TOTALFRAMES)
                    {
                        frameIndex = 0;
                    }
                }
            }

            //turn running frame each 0.1s
            else
            {
                while (time > frameTime)
                {
                    // Play the next frame in the SpriteSheet
                    frameIndexRunning++;

                    // reset elapsed time
                    time = 0f;

                    //reset the running goblin
                    if (frameIndexRunning > TOTALFRAMESRUNNING)
                    {
                        frameIndexRunning = 0;
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //load idle goblin in the beginning 
            spriteSheet = content.Load<Texture2D>("idle");

            //load running goblin
            spriteSheetRunning = content.Load<Texture2D>("running");
            //Vector2 Position = new Vector2(400, 300);
            base.LoadContent();
        }
        public override void Draw(GameTime gameTime)
        {
            //begin to draw goblin
            spriteBatch.Begin();

            //draw the idle goblin
            if (isIdle == 1)
            {
                spriteBatch.Draw(spriteSheet,
                player,
                goblinFrames.ElementAt<Rectangle>(frameIndex),
                Color.White,
                0f,                 //rotation in RADIANS
                new Vector2(0),     //origin
                0f,
                0f                  //layerdepth
                );
            }

            //draw right running goblin
            if (isIdle == 0 && isMovingLeft == 0)
            {
                spriteBatch.Draw(spriteSheetRunning,
                player,
                goblinFramesRunning.ElementAt<Rectangle>(frameIndexRunning),
                Color.White,
                0f,                 //rotation in RADIANS
                new Vector2(0),     //origin
                0f,
                0f                  //layerdepth
                );
            }

            //draw left running goblin
            if (isIdle == 0 && isMovingLeft == 1)
            {
                spriteBatch.Draw(spriteSheetRunning,
                player,
                goblinFramesRunning.ElementAt<Rectangle>(frameIndexRunning),
                Color.White,
                0f,                 //rotation in RADIANS
                new Vector2(0),     //origin
                SpriteEffects.FlipHorizontally, //left running
                0f                  //layerdepth
                );
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
