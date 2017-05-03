using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace spaceShooter
{
	public class Player
	{
		Game1 game;
		public Rectangle hitBox;
		public int changex;
		public Texture2D texture;
		GraphicsDeviceManager graphics;
		public Player(int x, int y, Game1 game, GraphicsDeviceManager graphics)
		{
			texture = game.Content.Load<Texture2D>("player");
			hitBox = new Rectangle(x, y, 99, 75);
			this.game = game;
			this.graphics = graphics;
		}

		public void update()
		{
			this.hitBox.X += this.changex;
			for (int i = game.enemies.Count - 1; i >= 0; i--)
			{
				if (this.hitBox.Intersects(game.enemies[i].hitBox))
				{
					this.game.Exit();
				}
			}
			if (this.hitBox.Left < 0)
			{
				this.hitBox.X = 0;
			}
			else if (this.hitBox.Right > graphics.PreferredBackBufferWidth)
			{
				this.hitBox.X = graphics.PreferredBackBufferWidth - hitBox.Width;
			}

			/*
			foreach (Enemy enemy in game.enemies)
			{
				if (this.hitBox.Intersects(enemy.hitBox)) {
					this.game.Exit();
				}
			}
			*/
		}

		public void shoot()
		{
			game.bullets.Add(new Bullet(hitBox.Right - (hitBox.Width/2), hitBox.Top - 33, this.game));
		}
	}
}
