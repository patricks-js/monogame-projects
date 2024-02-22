using System;
using System.Diagnostics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace ShootingGallery;

public class Crosshairs
{
    private readonly GraphicsDeviceManager _graphics;
    private Texture2D _texture;
    private Vector2 _position = new(100, 100);
    public Rectangle Bounds =>
        new((int)_position.X, (int)_position.Y, _texture.Width, _texture.Height);
    private SoundEffect _shootSoundEffect;
    private Song _movement;

    public Crosshairs(GraphicsDeviceManager graphics)
    {
        _graphics = graphics;
    }

    public void LoadContent(ContentManager content)
    {
        _texture = content.Load<Texture2D>("crosshairs");
        _shootSoundEffect = content.Load<SoundEffect>("shoot");
        _movement = content.Load<Song>("movement");
    }

    public void Update(GameTime gameTime)
    {
        var screenX = _graphics.PreferredBackBufferWidth;
        var screenY = _graphics.PreferredBackBufferHeight;

        var keyboard = Keyboard.GetState();

        if (keyboard.IsKeyDown(Keys.W) && _position.Y > 0)
        {
            _position.Y -= 10;
            MediaPlayer.Play(_movement);
        }
        if (keyboard.IsKeyDown(Keys.S) && _position.Y < screenY - _texture.Width)
        {
            _position.Y += 10;
            MediaPlayer.Play(_movement);
        }
        if (keyboard.IsKeyDown(Keys.A) && _position.X > 0)
        {
            _position.X -= 10;
            MediaPlayer.Play(_movement);
        }
        if (keyboard.IsKeyDown(Keys.D) && _position.X < screenX - _texture.Height)
        {
            _position.X += 10;
            MediaPlayer.Play(_movement);
        }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(_texture, _position, Color.White);
    }

    public void Shoot()
    {
        _shootSoundEffect.Play();
    }
}
