using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace RPG.Model;

public class Player
{
    private Vector2 _position = new(500, 300);
    private int _speed = 300;

    public Texture2D Sprite { get; set; }
    public Texture2D WalkUp { get; set; }
    public Texture2D WalkDown { get; set; }
    public Texture2D WalkLeft { get; set; }
    public Texture2D WalkRight { get; set; }
    public Vector2 Position
    {
        get => _position;
        set => _position = value;
    }

    public void LoadContent(ContentManager content)
    {
        Sprite = content.Load<Texture2D>("PLayer/player");
        WalkUp = content.Load<Texture2D>("PLayer/walkUp");
        WalkDown = content.Load<Texture2D>("PLayer/walkDown");
        WalkLeft = content.Load<Texture2D>("PLayer/walkLeft");
        WalkRight = content.Load<Texture2D>("PLayer/walkRight");
    }
}
