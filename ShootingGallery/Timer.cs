using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootingGallery;

public class Timer
{
    public double Time { get; private set; } = 40;
    private readonly SpriteFont _font;

    public Timer(SpriteFont font)
    {
        _font = font;
    }

    public void UpdateTimer(GameTime gameTime)
    {
        if (Time > 0)
        {
            Time -= gameTime.ElapsedGameTime.TotalSeconds;
        }

        if (Time < 0)
        {
            Time = 0;
        }
    }

    public void DrawTimer(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(
            _font,
            $"Time: {Math.Ceiling(Time)}",
            new Vector2(20, 60),
            Color.White
        );
    }
}
