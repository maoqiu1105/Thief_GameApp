using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace Thief
{
    //made by brad
    public class StartScene : GameScene
    {
        private MenuComponent menu;
        private ContentManager content;
        private SpriteFont titlefont;
        Texture2D background;
        public MenuComponent Menu
        {
            get { return menu; }
            set { menu = value; }
        }

        private SpriteBatch spriteBatch;
        string[] menuItems = {"Start Game",
                             "Help",
                             "Credit",
                             "Quit"};

        public StartScene(Game game, SpriteBatch spriteBatch,ContentManager content): base(game)
        {
            // TODO: Construct any child components here
            this.spriteBatch = spriteBatch;
            this.content = content;
            menu = new MenuComponent(game, spriteBatch,
                game.Content.Load<SpriteFont>("regularFont"),
                game.Content.Load<SpriteFont>("hilightFont"),
                menuItems);
            
            this.Components.Add(menu);
            LoadContent();
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
           
            //draw the background 
            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            //draw the title string
            spriteBatch.DrawString(titlefont, "Thief", new Vector2(320, 100), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        protected override void LoadContent()
        {
            //load the title font
            titlefont = content.Load<SpriteFont>("HUDfont");
            background = content.Load<Texture2D>("background");
            base.LoadContent();
        }
    }
}
