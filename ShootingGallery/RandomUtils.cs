using System;

namespace ShootingGallery;

public abstract class RandomUtils
{
    private static readonly Random Random = new();

    public static int Next(int min, int max)
    {
        return Random.Next(min, max);
    } 
}