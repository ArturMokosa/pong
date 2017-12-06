using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace pong.Classes
{
    class ClassBall : DrawableGameComponent

    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D pixel;
        Random rnd;

        int ballSize;

        public int speed { get; set; } = 1;
        public bool gameRun { get; set; }
        public int dirX { get; set; }
        public int dirY { get; set; }
        public int posX { get; set; }
        public int posY { get; set; }

        public ClassBall(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int ballSize) : base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.ballSize = ballSize;

            pixel = new Texture2D(graphics, 1, 1);
            pixel.SetData(new Color[] {Color.White});

            rnd = new Random();
        }

        public void ResetDirection()
        {
            do
            {
                dirX = rnd.Next(-10, 10);
            } while (dirX == 0);

            do
            {
                dirY = rnd.Next(-10, 10);
            } while (dirY == 0);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();

            spriteBatch.Draw(pixel, new Rectangle(posX, posY, ballSize, ballSize), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetBall()
        {
            posX = graphics.Viewport.Width / 2 - ballSize / 2;
            posY = graphics.Viewport.Height / 2 - ballSize / 2;
            ResetDirection();
        }

        public void CheckWallColision()
        {
            if (posY <= 0 || posY + ballSize > graphics.Viewport.Height)
            {
                dirY = -dirY;
            }
        }

        public void CheckRacketCollision(ClassRacket Player)
        {
           
        }
        
        public override void Update(GameTime gameTime)
        {
            if (gameRun)
            {
                posX += dirX * speed;
                posY += dirY * speed;

                CheckWallColision();
            }


            base.Update(gameTime);
        }
    }
}