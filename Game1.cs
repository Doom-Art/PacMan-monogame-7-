using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PacMan__monogame_7_
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D pacTex;
        Rectangle pacLoc;
        MouseState mouseState;
        KeyboardState keyboardState;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            pacLoc = new Rectangle(10, 10, 75, 75);
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            pacTex = Content.Load<Texture2D>("PacRight");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (keyboardState.IsKeyDown(Keys.Up) && pacLoc.Top > 0)
            {
                pacLoc.Y -= 2;
                pacTex = Content.Load<Texture2D>("PacUp");
            }
            else if (keyboardState.IsKeyDown(Keys.Down)&& pacLoc.Bottom < _graphics.PreferredBackBufferHeight)
            {
                pacLoc.Y += 2;
                pacTex = Content.Load<Texture2D>("PacDown");
            }
            else if (keyboardState.IsKeyDown(Keys.Left) && pacLoc.Left > 0)
            {
                pacLoc.X -= 2;
                pacTex = Content.Load<Texture2D>("PacLeft");
            }
            else if (keyboardState.IsKeyDown(Keys.Right) && pacLoc.Right < _graphics.PreferredBackBufferWidth)
            {
                pacLoc.X += 2;
                pacTex = Content.Load<Texture2D>("PacRight");
            }
            else
                pacTex = Content.Load<Texture2D>("PacSleep");
            if (mouseState.LeftButton == ButtonState.Pressed)
            {
                pacLoc.X = mouseState.X;
                pacLoc.Y = mouseState.Y;
            }

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(pacTex, pacLoc, Color.White);
            _spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}