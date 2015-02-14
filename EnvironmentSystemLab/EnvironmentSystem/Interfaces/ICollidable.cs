﻿namespace EnvironmentSystem.Interfaces
{
    using Models;
    using Models.Data.Structures;

    public interface ICollidable
    {
        Rectangle Bounds { get; }

        CollisionGroup CollisionGroup { get; }

        void RespondToCollision(CollisionInfo collisionInfo);
    }
}