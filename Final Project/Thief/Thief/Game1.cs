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
    /// <summary>
    /// Made by Kevin and Brad
    /// </summary>
    
    public class Game1 : Game
    {
        //float time;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //initialize all scene
        private ActionScene actionScene;
        private GameOverScene gameOverScene;
        private StartScene startScene;
        private HelpScene helpScene;
        private CreditsScene creditsScene;
        
        public static bool isDead;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.GraphicsProfile = GraphicsProfile.HiDef;
            IsMouseVisible = true;
        }

        //Hide all screen by for each loop
        private void HideAllScenes()
        {
            GameScene gs = null;
            foreach (GameComponent item in Components)
            {
                if (item is GameScene)
                {
                    gs = (GameScene)item;
                    gs.hide();
                }
            }
        }
        
        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            //add the game components
            actionScene = new ActionScene(this, spriteBatch,Content);
            Components.Add(actionScene);

            //add game over screen
            gameOverScene = new GameOverScene(this, spriteBatch, Content);
            Components.Add(gameOverScene);

            //add main menu screen
            startScene = new StartScene(this, spriteBatch, Content);
            Components.Add(startScene);

            //add help screen
            helpScene = new HelpScene(this, spriteBatch, Content);
            Components.Add(helpScene);

            //add credit screen
            creditsScene = new CreditsScene(this, spriteBatch,Content);
            Components.Add(creditsScene);

            //display main menu screen
            startScene.show();
        }

        protected override void Update(GameTime gameTime)
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            //add keyboard control
            KeyboardState ks = Keyboard.GetState();

            //select order in main menu
            int selectedIndex = 0;
            if (startScene.Enabled)
            {
                selectedIndex = startScene.Menu.SelectedIndex;

                //enter the game
                if (selectedIndex == 0 && ks.IsKeyDown(Keys.Enter))
                {
                    //reset the bomb, coin, and player position
                    Bomb.bombPos.Y = 0;
                    for (int i = 0; i < Coin.coins.Length; i++)
                    {
                        Coin.coins[i].Y = 0;
                    }
                    Coin.coin1.Y = 0;
                    Coin.coin2.Y = 0;
                    Coin.coin3.Y = 0;
                    Player.player.X = 400;
                    selectedIndex = 0;
                    HideAllScenes();
                    actionScene.show();
                }

                //enter help screen
                if (selectedIndex == 1 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    helpScene.show();
                }

                //enter credit screen
                if (selectedIndex == 2 && ks.IsKeyDown(Keys.Enter))
                {
                    HideAllScenes();
                    creditsScene.show();
                }

                //exit the game
                if (selectedIndex == 3 && ks.IsKeyDown(Keys.Enter))
                {
                    this.Exit();
                }
            }

            //display the gameover screen
            if (isDead == true)
            {
                HideAllScenes();
                gameOverScene.show();
            }
            
            //press space to get back to main menu
            if (gameOverScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Space))
                {
                    //time = 60;
                    //spacePressed = 0;
                    Score.time= 60;
                    Score.nScore = 0;
                    Score.nLives = 3;
                    isDead = false;
                    HideAllScenes();
                    startScene.show();
                }
            }

            //press escape to get back to main menu
            if (gameOverScene.Enabled || actionScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    //time = 60;
                    //spacePressed = 0;
                    Score.time = 60;
                    Score.nScore = 0;
                    Score.nLives = 3;
                    isDead = false;
                    //Background.instance.Stop();
                    HideAllScenes();
                    startScene.show();
                }
            }

            //get back to menu by press escape
            if (helpScene.Enabled || creditsScene.Enabled)
            {
                if (ks.IsKeyDown(Keys.Escape))
                {
                    HideAllScenes();
                    startScene.show();
                }
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
        
    }
}
