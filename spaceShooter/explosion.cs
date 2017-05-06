using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace spaceShooter
{
	public class Explosion
	{
		public Texture2D texture;
		public Rectangle hitBox;
		Game1 game;
		GraphicsDeviceManager graphics;
		int life;

		public Explosion(int x, int y, Game1 game, GraphicsDeviceManager graphics) {
			this.game = game;
			this.texture = this.game.Content.Load<Texture2D>("explosion");
			this.graphics = graphics;
			this.hitBox = new Rectangle(x, y, this.texture.Width, this.texture.Height);
			this.life = 5;
		}

		public void update()
		{
			life -= 1;
			if (life <= 0)
			{
				game.explosions.Remove(this);
			}
		}
	}
} 