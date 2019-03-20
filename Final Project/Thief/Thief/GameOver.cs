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

namespace Thief
{
    //made by brad
    class GameOver : DrawableGameComponent
    {
        Texture2D go;
        SpriteFont HUDfont;
        public static SoundEffect goSound;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        public GameOver(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //draw game over at screen
            spriteBatch.Draw(go, new Rectangle(0, 0, 800, 480), Color.White);
            //draw the score string
            spriteBatch.DrawString(HUDfont, "Score: ", new Vector2(350, 220), Color.Yellow);
            spriteBatch.DrawString(HUDfont, Score.scoreString, new Vector2(400, 220), Color.Yellow);
            spriteBatch.End();
            base.Draw(gameTime);
        }
        

        protected override void LoadContent()
        {
            //load gameover image
            go = content.Load<Texture2D>("GameOverScreen");
            //load text font
            HUDfont = content.Load<SpriteFont>("HUDfont");
            //load game over sound
            goSound = content.Load<SoundEffect>("gameoversound");
            base.LoadContent();
        }
    }
}
