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
    //made by Brad
    class Credits : DrawableGameComponent

    {
        Texture2D credits;
        private ContentManager content;
        private SpriteBatch spriteBatch;
        public Credits(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            //draw the credit screen
            spriteBatch.Draw(credits, new Rectangle(0, 0, 800, 480), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            //load the credit screen
            credits = content.Load<Texture2D>("CreditsScreen");
            base.LoadContent();
        }
    }
}
