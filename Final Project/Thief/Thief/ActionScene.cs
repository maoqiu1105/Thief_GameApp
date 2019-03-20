using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Thief;

namespace Thief
{
    public class ActionScene : GameScene
    {
        //set the screen size
        const int SCREENWIDTH = 800;
        const int SCREENHEIGHT = 440;
        private SpriteBatch spriteBatch;
        private ContentManager content;
        Random random = new Random();
        Background bg;

        public ActionScene(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;

            //add content
            bg = new Background(game, spriteBatch, content);
            Components.Add(bg);

            //add a player
            Player player = new Player(game, spriteBatch, content, bg);
            Components.Add(player);
            
            //add coins at random position
            Coin c = new Coin(game, spriteBatch, content);
            Components.Add(c);

            //add bomb 
            Bomb b = new Bomb(game, spriteBatch, content, bg,player);
            Components.Add(b);

            //add score text
            Score score = new Score(game, spriteBatch, content, bg, player);
            Components.Add(score);
        }

        public override void show()
        {
            //play the background song when start the game
            bg.StartBackgroundMusic();
            this.Enabled = true;
            this.Visible = true;
        }
        public override void hide()
        {
            
            if (bg != null)
            {
                //hide the song when the game over
                bg.StopBackgroundMusic();
            }
            this.Enabled = false;
            this.Visible = false;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
    }
}
