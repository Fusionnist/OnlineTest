using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Lidgren;
using Lidgren.Network;

namespace Template
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Sprite ship;
        RenderTarget2D InterfaceTarget, GameTarget;
        Vector2 translation;
        NetPeerConfiguration peerConfig;
        NetPeer peer;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 600;
            graphics.ApplyChanges();

            Content.RootDirectory = "Content";

            peerConfig = new NetPeerConfiguration("TestGame");
            peerConfig.Port = 8000;
            peer = new NetPeer(peerConfig);
            peer.Start();
        }
        void CalcTranslation()
        {
            translation = ship.pos - new Vector2(284, 284);
        }
        protected override void Initialize()
        {
            InterfaceTarget = new RenderTarget2D(GraphicsDevice, 600, 600);
            GameTarget = new RenderTarget2D(GraphicsDevice, 600, 600);
            ship = new Sprite(Content.Load<Texture2D>("ship"), new Vector2(0, 0));
            base.Initialize();
        }
        void HandleWebConnections()
        {
            NetIncomingMessage message;
            while ((message = peer.ReadMessage()) != null)
            {
                switch (message.MessageType)
                {
                    case NetIncomingMessageType.Data:
                        string data = message.ReadString();
                        break;

                    case NetIncomingMessageType.StatusChanged:
                        switch (message.SenderConnection.Status)
                        {

                        }
                        break;

                    case NetIncomingMessageType.DebugMessage:
                        Console.WriteLine(message.ReadString());
                        break;

                    default:
                        Console.WriteLine("unhandled message with type: "
                            + message.MessageType);
                        break;
                }
            }
        }
        void UpdateWebConnections()
        {

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

            Vector2 mov = Vector2.Zero;
            if (Keyboard.GetState().IsKeyDown(Keys.Down)) { mov.Y += 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Up)) { mov.Y -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Left)) { mov.X -= 3; }
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { mov.X += 3; }
            ship.Move(mov);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(GameTarget);
            float x = Math.Abs(ship.pos.X / 1000);
            float y = Math.Abs(ship.pos.Y / 1000);
            Color c = new Color(x, y, x + y/2);
            GraphicsDevice.Clear(c);
            CalcTranslation();
            Matrix m = Matrix.CreateTranslation(new Vector3(-translation.X, -translation.Y, 0)) * Matrix.CreateScale(1f);
            spriteBatch.Begin(transformMatrix: m);
            ship.Draw(spriteBatch);
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(InterfaceTarget);
            GraphicsDevice.Clear(Color.TransparentBlack);
            spriteBatch.Begin();
            //draw interface
            spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            spriteBatch.Begin();
            spriteBatch.Draw(texture: GameTarget, position: Vector2.Zero);
            spriteBatch.Draw(texture: InterfaceTarget, position: Vector2.Zero);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
