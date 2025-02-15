﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using pong.Classes;
using Microsoft.Xna.Framework.Content;

namespace pong
{
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        ClassBall ball;
        ClassRacket P1;
        ClassRacket P2;
        SpriteFont font;

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
            font = Content.Load<SpriteFont>("font");

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
            else if (Keyboard.GetState().IsKeyDown(Keys.R) && ball.gameRun)
            {
                ball.gameRun = false;
                ball.ResetBall();
            }

            
            P1.posY = Mouse.GetState().Y;
            P2.posY = ball.posY / 1.4 + 25;
            

            if (ball.dirX > 0)
            {
                // ball.CheckRacketCollision(P2);
                if (ball.posY >= P2.posY && ball.posY + ballSize < P2.posY + racketHeight &&
                    ball.posX + ballSize >= P2.posX)
                {
                    ball.dirX = -ball.dirX;
                }
                else if (ball.posX >= GraphicsDevice.Viewport.Width - ballSize)
                {
                    scoreP1++;
                    ball.gameRun = false;
                    ball.ResetBall();
                }
            }
            else if (ball.dirX < 0)
            {
                // ball.CheckRacketCollision(P1);
                if (ball.posY >= P1.posY && ball.posY + ballSize <= P1.posY + racketHeight &&
                    ball.posX <= P1.posX + racketWidht)
                {
                    ball.dirX = -ball.dirX;
                }
                else if (ball.posX <= 0)
                {
                    scoreP2++;
                    ball.gameRun = false;
                    ball.ResetBall();
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(new Color(51, 51, 51));
            spriteBatch.Begin();
            spriteBatch.DrawString(font, scoreP1.ToString(), new Vector2(50, 50), new Color(45, 45, 45, 20));
            spriteBatch.DrawString(font, scoreP2.ToString(), new Vector2(GraphicsDevice.Viewport.Width -250, 50), new Color(45, 45, 45, 20));
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}