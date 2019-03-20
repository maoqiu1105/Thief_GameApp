using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

// Made by Kevin
namespace Thief
{
    class Bomb : DrawableGameComponent
    {
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private Rectangle bombFram;
        public static Rectangle bombPos;
        private SoundEffect bombSound;
        private Background background;
        private Player player;
        Texture2D bomb;
        private Random random = new Random();

        const int GAMEPIXEL = 30;

        public Bomb(Game game, SpriteBatch spriteBatch, ContentManager content,Background background, Player player) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.background = background;
            this.player = player;

            //bomb position when begin the game
            bombPos = new Rectangle(random.Next(0,750), 0, GAMEPIXEL, GAMEPIXEL);

            //select the bomb in source file
            bombFram = new Rectangle(13, 19, 115, 109);
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            //draw the bomb in game
            spriteBatch.Begin();
            spriteBatch.Draw(bomb, bombPos, bombFram, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public override void Update(GameTime gameTime)
        {
            //bomb fall down speed in random 3-7
            bombPos.Y += random.Next(3, 7);

            //reset the bomb when bomb disapper in the buttom of screen
            if (bombPos.Y > 340)
            {
                BombFall();
            }

            //the character touch the bomb
            if (bombPos.Intersects(Player.player))
            {
                //play the boom sound
                bombSound.Play();

                //subtract the live 
                Score.nLives -= 1;

                //game will be end when the life is zero
                if (Score.nLives <= 0)
                {
                    //Background.instance.IsLooped = false;
                    //Background.instance.Stop();
                    //Player.player.X = 0;
                    GameOver.goSound.Play();
                    Game1.isDead = true;
                }
            
                //bomb reset and fall again
                BombFall();
            }
            base.Update(gameTime);
        }

        //bomb fall down method
        public void BombFall()
        {
            bombPos.Y = 0;
            bombPos.X = random.Next(0, 750);
        }

        protected override void LoadContent()
        {
            //load the bomb image
            bomb = content.Load<Texture2D>("bomb");

            //load the bomb sound
            bombSound = content.Load<SoundEffect>("bombsound");
            base.LoadContent();
        }
    }
}

