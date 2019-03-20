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
    //made by brad
    public class HelpScene : GameScene
    {
        private SpriteBatch spriteBatch;
        private ContentManager content;
        HelpScreen help;
        public HelpScene(Game game, SpriteBatch spriteBatch, ContentManager content) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.content = content;
            help = new HelpScreen(game, spriteBatch, content);
            Components.Add(help);
        }
        public override void show()
        {
            this.Enabled = true;
            this.Visible = true;
        }
        public override void hide()
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}