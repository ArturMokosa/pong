using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace pong.Classes
{
    class ClassRacket : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        GraphicsDevice graphics;
        Texture2D pixel;

        int width;
        int height;
        public int posY { get; set; }
        public int posX { get; set; }

        public ClassRacket(GraphicsDevice graphics, SpriteBatch spriteBatch, Game game, int width, int height, int posX,
            int posY) :
            base(game)
        {
            this.spriteBatch = spriteBatch;
            this.graphics = graphics;
            this.posX = posX;
            this.posY = posY;
            this.height = height;
            this.width = width;

            pixel = new Texture2D(graphics, 1, 1);

            pixel.SetData(new Color[] {Color.White});
        }

        public override void Update(GameTime gameTime)
        {
            ////posY = Mouse.GetState().Y;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(pixel, new Rectangle(posX, posY, width, height), Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}