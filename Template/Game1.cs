using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ship;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";
        }
        protected override void Initialize()
        {
            ship = new Sprite(Content.Load<Texture2D>("ship"), new Vector2(300, 300));
            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }
        protected override void UnloadContent()
        {
           // bite (test)
        }
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) { ship.pos.Y += 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) { ship.pos.Y -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) { ship.pos.X -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { ship.pos.X += 3; }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            ship.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
