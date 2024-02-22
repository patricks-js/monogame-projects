using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Model;

public class Skull
{
    public Texture2D sprite;

    public void LoadContent(ContentManager content)
    {
        sprite = content.Load<Texture2D>("skull");
    }
}
