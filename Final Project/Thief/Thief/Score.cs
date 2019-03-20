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
using System.Timers;

namespace Thief
{
    //made by brad and kevin
    class Score : DrawableGameComponent
    {
        Background background;
        Player player;
        SpriteFont HUDfont;
        public static int time = 60;
        public static int nScore = 0;
        public static int nLives = 3;
        public static string scoreString;
        public static string livesString;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        private DateTime gameStart;
        public Score(Game game, SpriteBatch spriteBatch, ContentManager content, Background background, Player player) : base(game)
        {
            
            this.background = background;
            this.spriteBatch = spriteBatch;
            this.content = content;
            this.player = player;

            LoadContent();
        }
        
        protected override void LoadContent()
        {
            //load the text font
            HUDfont = content.Load<SpriteFont>("HUDfont");
            base.LoadContent();
        }


        public override void Draw(GameTime gameTime)
        {
            //get the remaining time
            if (DateTime.Now > gameStart.AddSeconds(1) && time != 0)
            {
                time--;
                gameStart = DateTime.Now;
            }

            //game is over by time to zero
            if (time == 0)
            {
                Game1.isDead = true;
            }


            spriteBatch.Begin();
            //print the score
            spriteBatch.DrawString(HUDfont, "Score: ", new Vector2(50, 15), Color.White);
            scoreString = string.Format("{0,12}", nScore);
            spriteBatch.DrawString(HUDfont, scoreString, new Vector2(70, 15), Color.White);

            //print the lives
            spriteBatch.DrawString(HUDfont, "Lives: ", new Vector2(200, 15), Color.White);
            livesString = string.Format("{0,12}", nLives);
            spriteBatch.DrawString(HUDfont, livesString, new Vector2(210, 15), Color.White);

            //print the time remaining
            spriteBatch.DrawString(HUDfont, "Time: ", new Vector2(350, 15), Color.White);
            string timeString = string.Format("{0,12}", time);
            spriteBatch.DrawString(HUDfont, timeString, new Vector2(360, 15), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
