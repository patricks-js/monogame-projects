using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Spaceship.Model;

namespace Spaceship.Controller;

public class AsteroidController
{
    public List<Asteroid> asteroids = new();
    public double timer = 2;
    public double maxTime = 2;
    public int nextSpeed = 250;

    public void Update(GameTime gameTime)
    {
        timer -= gameTime.ElapsedGameTime.TotalSeconds;

        if (timer <= 0)
        {
            asteroids.Add(new(250));
            timer = maxTime;

            if (maxTime >= 0.5)
                maxTime -= 0.1;

            if (nextSpeed < 720)
                nextSpeed += 4;
        }
    }
}
