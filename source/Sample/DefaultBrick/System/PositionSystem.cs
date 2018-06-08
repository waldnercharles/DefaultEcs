﻿using System;
using DefaultBrick.Component;
using DefaultEcs;
using DefaultEcs.System;
using Microsoft.Xna.Framework;

namespace DefaultBrick.System
{
    public class PositionSystem : ASystem<float>
    {
        public PositionSystem(World world, SystemRunner<float> runner)
            : base(world.GetEntities().With<Position>().With<DrawInfo>().Build(), runner)
        {
        }

        protected override void InternalUpdate(float elaspedTime, ReadOnlySpan<Entity> entities)
        {
            foreach (Entity entity in entities)
            {
                Vector2 position = entity.Get<Position>().Value;
                ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();

                drawInfo.Destination.X = (int)position.X;
                drawInfo.Destination.Y = (int)position.Y;
            }
        }
    }
}
