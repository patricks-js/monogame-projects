using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ShootingGallery;

public class Score
{
    private int ScoreCount { get; set; }
    private readonly SpriteFont _font;

    public Score(SpriteFont gameFont)
    {
        _font = gameFont;
    }
    
    public void IncrementScore()
    {
        ScoreCount += 10;
    }

    public void DrawScore(SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(
            _font,
            $"Score: {ScoreCount}",
            new Vector2(20, 20),
            Color.White
        );
    }
}
