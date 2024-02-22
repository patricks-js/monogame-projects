using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Spaceship.Model;

public class Ship
{
    public static Vector2 defaultPos = new(640, 360);
    public Vector2 _position = new(100, 100);
    private int _speed = 180;
    public int radius = 34;
    public Rectangle bounds;

    public void Update(GameTime gameTime)
    {
        var keyboard = Keyboard.GetState();
        double dt = gameTime.ElapsedGameTime.TotalSeconds;

        float dtSpeed = (float)(_speed * dt);

        if (keyboard.IsKeyDown(Keys.Right))
            _position.X += dtSpeed;
        if (keyboard.IsKeyDown(Keys.Left))
            _position.X -= dtSpeed;
        if (keyboard.IsKeyDown(Keys.Up))
            _position.Y -= dtSpeed;
        if (keyboard.IsKeyDown(Keys.Down))
            _position.Y += dtSpeed;
    }
}
