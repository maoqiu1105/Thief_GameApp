using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;

// Made by Brad and Kevin
namespace Thief
{
    class Background : DrawableGameComponent
    {
        Texture2D bg;
        ContentManager content;
        SpriteBatch spriteBatch;
        Song backgroundMusic;

        public void StopBackgroundMusic()
        {
            //background music stop
            MediaPlayer.Stop();
        }

        public void StartBackgroundMusic()
        {
            //play the background music
            MediaPlayer.Play(backgroundMusic);
        }

        public Background(Game game,SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            //draw the game background image
            spriteBatch.Begin();
            spriteBatch.Draw(bg, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        

        protected override void LoadContent()
        {
            //load the background image
            bg = content.Load<Texture2D>("background");

            //load the background music
            backgroundMusic = content.Load<Song>("backgroundmusic");

            //set background music repeat
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Volume = 0.2f;
            base.LoadContent();

        }
    }
}
