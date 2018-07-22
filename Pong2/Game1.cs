using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong2.Content;
using Microsoft.CSharp.RuntimeBinder;
using System.Diagnostics;
using System;
namespace Pong2
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Paddle paddle1;
        Paddle paddle2;
        Texture2D paddleSprite;
        Texture2D ballSprite;
        CollisionHandler collisionHandler;
        Ball ball;

        public Ball ball_ {
            get{ return ball; }
        }
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            paddle1 = new Paddle(this, 1,new Vector2(25,0));
            paddle2 = new Paddle(this, 2,new Vector2(800-50,0));
            ball = new Ball(new Vector2(800/2,380/2),1);
            collisionHandler = new CollisionHandler();
        }
        protected override void Initialize()
        {
            base.Initialize();

        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            paddleSprite = Content.Load<Texture2D>("Paddle");
            ballSprite = Content.Load<Texture2D>("Ball");


        }
        protected override void UnloadContent()
        {
        }
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            paddle1.Update(gameTime);
            paddle2.Update(gameTime);
            ball.Update(gameTime);
            if ((paddle2.Position.Y + (paddle2.Size.Y / 2)) < ball.Position.Y)
            {
                paddle2.Direction = -1;
            }
            else
            {
                paddle2.Direction = 1;
            }
            var ballCollide1 = collisionHandler.collidesMTV(paddle1, ball);
            var ballCollide2 = collisionHandler.collidesMTV(paddle2, ball);

            if ((bool)ballCollide1[0])
            {
                Random r = new Random();
                int randValue = r.Next(1, 5) * 2;
                Vector2 newVelocity = new Vector2(-ball.Velocity.X+(1*10), (-ball.Velocity.Y*2)+(randValue));
                ball.Position = ball.Position + (Vector2)ballCollide1[1];
                ball.Velocity = newVelocity;
            }
            if ((bool)ballCollide2[0])
            {

                Random r = new Random();
                int randValue = r.Next(1, 5) * 2;
                Vector2 newVelocity = new Vector2(-ball.Velocity.X + (-10), (-ball.Velocity.Y * 2) + (-randValue));
                ball.Position = ball.Position + (Vector2)ballCollide2[1];
                ball.Velocity = newVelocity;

            }
            Debug.Print(ball.Velocity.X.ToString());

        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            spriteBatch.Draw(paddleSprite, paddle1.Position, Color.White);
            spriteBatch.Draw(paddleSprite, paddle2.Position, Color.White);
            spriteBatch.Draw(ballSprite, ball.Position, Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

    }
}
