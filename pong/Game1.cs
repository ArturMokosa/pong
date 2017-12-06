using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using pong.Classes;

namespace pong
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ClassBall ball;
        ClassRacket P1;
        ClassRacket P2;

        int scoreP1 = 0;
        int scoreP2 = 0;
        int racketWidht = 10;
        int racketHeight = 100;
        int ballSize = 10;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ball = new ClassBall(GraphicsDevice, spriteBatch, this, ballSize);

            P1 = new ClassRacket(GraphicsDevice, spriteBatch, this, racketWidht, racketHeight, 10,
                GraphicsDevice.Viewport.Height / 2 - racketHeight / 2);
            P2 = new ClassRacket(GraphicsDevice, spriteBatch, this, racketWidht, racketHeight,
                GraphicsDevice.Viewport.Width - 10 - racketWidht,
                GraphicsDevice.Viewport.Height / 2 - racketHeight / 2);

            Components.Add(P1);
            Components.Add(P2);
            Components.Add(ball);

            ball.ResetBall();
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            else if (Keyboard.GetState().IsKeyDown(Keys.Space) && !ball.gameRun)
            {
                ball.gameRun = true;
            }

            P1.posY = Mouse.GetState().Y;
            P2.posY = Mouse.GetState().Y;

            if (ball.dirX > 0)
            {
                ///ball.CheckRacketCollision(P2);
                if (ball.posY >= P2.posY && ball.posY + ballSize < P2.posY + racketHeight && ball.posX >= P2.posX) //8:52
                {
                    
                }
            }
            else if (ball.dirX < 0)
            {
                ball.CheckRacketCollision(P1);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(51, 51, 51));

            base.Draw(gameTime);
        }
    }
}