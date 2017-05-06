using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace spaceShooter
{
	public class Bullet
	{
		Game1 game;
		public Texture2D texture;
		public Rectangle hitBox;
		public int changey;
		public Bullet(int x, int y, Game1 game)
		{
			this.game = game;
			this.texture = this.game.Content.Load<Texture2D>("laserRed");
			this.hitBox = new Rectangle(x, y, this.texture.Width, this.texture.Height );
			this.changey = -4;
		}
		public void update()
		{
			this.hitBox.Y += this.changey;
			if (hitBox.Bottom < 0)
			{
				this.game.bullets.Remove(this);
			}
			for (int i = game.enemies.Count - 1; i >= 0; i--)
			{
				{
					if (hitBox.Intersects(game.enemies[i].hitBox))
					{
						game.enemies[i].explode();
						game.enemies[i].changePosition();
						this.game.score += 1;
						this.game.bullets.Remove(this);
					}
				}
			}
		}
	}
}