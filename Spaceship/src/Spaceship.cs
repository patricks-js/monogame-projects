using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Spaceship.Controller;
using Spaceship.Model;

namespace Spaceship;

public class Spaceship : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private Texture2D _background;
    private Texture2D _ship;
    private Texture2D _asteroid;
    private SpriteFont _gameFont;
    private SpriteFont _timerFont;

    private Ship _player = new();
    private AsteroidController controller = new();

    public Spaceship()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _graphics.PreferredBackBufferWidth = 1280;
        _graphics.PreferredBackBufferHeight = 720;
        _graphics.ApplyChanges();

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _background = Content.Load<Texture2D>("space");
        _asteroid = Content.Load<Texture2D>("asteroid");
        _ship = Content.Load<Texture2D>("ship");

        _gameFont = Content.Load<SpriteFont>("Fonts/Game");
        _timerFont = Content.Load<SpriteFont>("Fonts/Timer");
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        _player.Update(gameTime);

        _player.bounds = new(
            (int)_player._position.X,
            (int)_player._position.Y,
            _ship.Width,
            _ship.Height
        );

        controller.Update(gameTime);

        for (int i = 0; i < controller.asteroids.Count; i++)
        {
            var a = controller.asteroids[i];
            a.Update(gameTime);

            a.bounds = new((int)a.position.X, (int)a.position.Y, _asteroid.Width, _asteroid.Height);

            if (_player.bounds.Intersects(a.bounds))
            {
                controller.asteroids.Clear();
                _player._position = Ship.defaultPos;
            }
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        var centerShip = new Vector2(
            _player._position.X - _ship.Width / 2,
            _player._position.Y - _ship.Height / 2
        );

        _spriteBatch.Begin();

        _spriteBatch.Draw(_background, Vector2.Zero, Color.White);
        _spriteBatch.Draw(_ship, centerShip, Color.White);

        foreach (var a in controller.asteroids)
        {
            _spriteBatch.Draw(
                _asteroid,
                new Vector2(a.position.X - a.radius, a.position.Y - a.radius),
                Color.White
            );
        }

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
