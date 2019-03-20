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

namespace Thief
{
    //made by brad
    class HelpScreen : DrawableGameComponent
    {
        Texture2D help;
        private ContentManager content;
        private SpriteBatch spriteBatch;

        public HelpScreen(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //draw the help screen
            spriteBatch.Draw(help, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            //load the help image
            help = content.Load<Texture2D>("HelpScreen");
            base.LoadContent();
        }
    }
}
