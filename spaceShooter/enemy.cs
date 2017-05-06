using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace spaceShooter
{
	public class Enemy
	{
		public Texture2D texture;
		Game1 game;
		public Rectangle hitBox;
		public int changey;
		GraphicsDeviceManager graphics;
		Random rand = new Random();
		public Enemy(int x, int y, Game1 game, GraphicsDeviceManager graphics)
		{
			this.game = game;
			this.graphics = graphics;
			this.texture = this.game.Content.Load<Texture2D>("enemyShip");
			hitBox = new Rectangle(x, y, 98, 50);
			this.changey = 4;
		}
		public void update()
		{
			this.hitBox.Y += this.changey;
			if (this.hitBox.Y > graphics.PreferredBackBufferHeight)
			{
				changePosition();
			}
		}
		public void changePosition()
		{
			hitBox.Y = 0;
  			hitBox.X = rand.Next(0, graphics.PreferredBackBufferWidth - hitBox.Width);
		}
	}  
}