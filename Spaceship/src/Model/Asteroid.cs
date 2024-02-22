using System;
using Microsoft.Xna.Framework;

namespace Spaceship.Model;

public class Asteroid
{
    public Vector2 position = new(600, 300);
    public int speed;
    public int radius = 59;
    Random random = new();
    public Rectangle bounds;

    public Asteroid(int newSpeed)
    {
        speed = newSpeed;
        position = new Vector2(1380, random.Next(radius, 720 - radius));
    }

    public void Update(GameTime gameTime)
    {
        float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

        position.X -= speed * dt;
    }
}
