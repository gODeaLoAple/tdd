﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using TagsCloudVisualization.Extensions;

namespace TagsCloudVisualization
{
    public class DistantPointFinder
    {
        private readonly Point _center;

        public DistantPointFinder(Point center)
        {
            _center = center;
        }

        public Point GetDistantPoint(IEnumerable<Point> points)
        {
            return points.Aggregate((best, current) =>
                _center.DistanceTo(current) > _center.DistanceTo(best) ? current : best);
        }
    }
}