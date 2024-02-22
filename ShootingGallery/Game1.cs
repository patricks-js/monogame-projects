using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootingGallery;

public class Game1 : Game
{
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;

    private Texture2D _backgroundSprite;
    private SpriteFont _gameFont;
    private Score _score;
    private Timer _timer;
    private Target _target;
    private Crosshairs _crosshairs;
    private bool _spaceKeyReleased = true;

    // private MouseState _mouseState;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        _target = new Target(_graphics);
        _crosshairs = new Crosshairs(_graphics);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        _backgroundSprite = Content.Load<Texture2D>("sky");
        _gameFont = Content.Load<SpriteFont>("Pixelify Sans");

        _crosshairs.LoadContent(Content);
        _target.LoadContent(Content);
        _score = new Score(_gameFont);
        _timer = new Timer(_gameFont);
    }

    protected override void Update(GameTime gameTime)
    {
        if (
            GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed
            || Keyboard.GetState().IsKeyDown(Keys.Escape)
        )
            Exit();

        KeyboardState keyboardState = Keyboard.GetState();

        _timer.UpdateTimer(gameTime);

        // _mouseState = Mouse.GetState();

        _crosshairs.Update(gameTime);
        // _target.Update(gameTime, _mouseState, _timer.Time, _score);
        _target.Update(gameTime, _timer.Time, _score);

        if (
            _crosshairs.Bounds.Intersects(_target.Bounds)
            && keyboardState.IsKeyDown(Keys.Space)
            && _spaceKeyReleased
            && _timer.Time > 0
        )
        {
            _target.WasHit = true;
            _crosshairs.Shoot();
            _spaceKeyReleased = false;
        }

        if (keyboardState.IsKeyUp(Keys.Space))
        {
            _spaceKeyReleased = true;
        }

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        _spriteBatch.Draw(_backgroundSprite, new Vector2(0, 0), Color.White);

        _timer.DrawTimer(_spriteBatch);
        _score.DrawScore(_spriteBatch);
        if (_timer.Time > 0)
            _target.Draw(_spriteBatch);
        _crosshairs.Draw(_spriteBatch);

        _spriteBatch.End();

        base.Draw(gameTime);
    }
}
