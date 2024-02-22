using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ShootingGallery;

public class Target
{
    private readonly GraphicsDeviceManager _graphics;
    private Texture2D _texture;
    private Vector2 _position = new(300, 300);
    private const int TargetRadius = 45;
    public Rectangle Bounds =>
        new(
            (int)_position.X - TargetRadius,
            (int)_position.Y - TargetRadius,
            _texture.Width,
            _texture.Height
        );
    private SoundEffect _effect;
    public bool WasHit { get; set; } = false;

    public Vector2 Position
    {
        get => _position;
        set
        {
            _position = value;
            _position = Position;
        }
    }

    private bool _mouseReleased = true;

    public Target(GraphicsDeviceManager graphics)
    {
        _graphics = graphics;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("target");
        _effect = content.Load<SoundEffect>("shoot");
    }

    public void Update(GameTime gameTime, MouseState mouseState, double timer, Score score)
    {
        if (mouseState.LeftButton == ButtonState.Pressed && _mouseReleased)
        {
            var mouseTargetDist = Vector2.Distance(_position, mouseState.Position.ToVector2());

            if (mouseTargetDist < TargetRadius && timer > 0)
            {
                score.IncrementScore();
                _effect.Play();

                _position.X = RandomUtils.Next(
                    TargetRadius,
                    _graphics.PreferredBackBufferWidth - TargetRadius
                );
                _position.Y = RandomUtils.Next(
                    TargetRadius,
                    _graphics.PreferredBackBufferHeight - TargetRadius
                );
            }

            _mouseReleased = false;
        }

        if (mouseState.LeftButton == ButtonState.Released)
            _mouseReleased = true;
    }

    public void Update(GameTime gameTime, double timer, Score score)
    {
        if (WasHit && timer > 0)
        {
            score.IncrementScore();

            _position.X = RandomUtils.Next(
                TargetRadius,
                _graphics.PreferredBackBufferWidth - TargetRadius
            );
            _position.Y = RandomUtils.Next(
                TargetRadius,
                _graphics.PreferredBackBufferHeight - TargetRadius
            );
        }

        WasHit = false;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(
            _texture,
            new Vector2(_position.X - TargetRadius, _position.Y - TargetRadius),
            Color.White
        );
    }
}
