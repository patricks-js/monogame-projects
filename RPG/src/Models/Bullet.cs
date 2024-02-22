using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Model;

public class Bullet
{
    public Texture2D sprite;

    public void LoadContent(ContentManager content)
    {
        sprite = content.Load<Texture2D>("ball");
    }
}
