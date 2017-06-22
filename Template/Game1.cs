using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Vector2 pos;
        Texture2D tex;
        
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
            pos = new Vector2(300, 300);
            base.Initialize();
        }
        protected override void LoadContent()
        {
            tex = Content.Load<Texture2D>("ship");
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

            if (Keyboard.GetState().IsKeyDown(Keys.Down)) { pos.Y += 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) { pos.Y -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) { pos.X -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { pos.X += 3; }
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(tex, pos, null);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
