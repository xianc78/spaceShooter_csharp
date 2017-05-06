using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace spaceShooter
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;
		Player player;
		//public Bullet[] bullets = new Bullet[20];
		public List<Bullet> bullets = new List<Bullet>();
		public List<Enemy> enemies = new List<Enemy>();
		public int score;
		KeyboardState prevState;
		Random rand = new Random();
		public const int SCREEN_WIDTH = 640;
		public const int SCREEN_HEIGHT = 480;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			graphics.PreferredBackBufferWidth = SCREEN_WIDTH;
			graphics.PreferredBackBufferHeight = SCREEN_HEIGHT;
		}

		/// <summary>
		/// Allows the game to perform any initialization it needs to before starting to run.
		/// This is where it can query for any required services and load any non-graphic
		/// related content.  Calling base.Initialize will enumerate through any components
		/// and initialize them as well.
		/// </summary>
		protected override void Initialize()
		{
			int nextRand;
			player = new Player(0, graphics.PreferredBackBufferHeight - 75, this, this.graphics);
			for (int i = 0; i < 3; i++)
			{
				nextRand = rand.Next(0, graphics.PreferredBackBufferWidth - 50);
				enemies.Add(new Enemy(nextRand, 0, this, this.graphics));
			}
			base.Initialize();
		}

		/// <summary>
		/// LoadContent will be called once per game and is the place to load
		/// all of your content.
		/// </summary>
		protected override void LoadContent()
		{
			// Create a new SpriteBatch, which can be used to draw textures.
			spriteBatch = new SpriteBatch(GraphicsDevice);

			//TODO: use this.Content to load your game content here 
		}

		/// <summary>
		/// Allows the game to run logic such as updating the world,
		/// checking for collisions, gathering input, and playing audio.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Update(GameTime gameTime)
		{
			// For Mobile devices, this logic will close the Game when the Back button is pressed
			// Exit() is obsolete on iOS
#if !__IOS__ && !__TVOS__
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
#endif
			KeyboardState state = Keyboard.GetState();

			player.changex = 0;
			if (state.IsKeyDown(Keys.Left)) {
				player.changex = -6;
			}
			    else if (state.IsKeyDown(Keys.Right)) {
				player.changex = 6;
			}
			if (state.IsKeyDown(Keys.Space) && !prevState.IsKeyDown(Keys.Space)) {
				player.shoot();
			}
			player.update();
			for (int i = bullets.Count - 1; i >= 0; i--)
			{
				bullets[i].update();
			}
			for (int i = enemies.Count - 1; i >= 0; i--)
			{
				enemies[i].update();
			}
			base.Update(gameTime);
			prevState = state;
			this.Window.Title = "Space Shooter | Score: " + score;
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			graphics.GraphicsDevice.Clear(Color.Black);

			//TODO: Add your drawing code here
			spriteBatch.Begin();
			spriteBatch.Draw(player.texture, destinationRectangle: player.hitBox);
			foreach (Bullet bullet in bullets)
			{
				spriteBatch.Draw(bullet.texture, destinationRectangle: bullet.hitBox);
			}
			foreach (Enemy enemy in enemies)
			{
				spriteBatch.Draw(enemy.texture, destinationRectangle: enemy.hitBox);
			}
			spriteBatch.End();

			base.Draw(gameTime);
		}
	}
}
