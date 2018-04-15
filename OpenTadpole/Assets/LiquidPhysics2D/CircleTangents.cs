using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

class CircleTangents
{
        // Find the tangent points for these two circles.
        // Return the number of tangents: 4, 2, or 0.
        public static int FindCircleCircleTangents(
            Vector2 c1, float radius1, Vector2 c2, float radius2,
            out Vector2 outer1_p1, out Vector2 outer1_p2,
            out Vector2 outer2_p1, out Vector2 outer2_p2,
            out Vector2 inner1_p1, out Vector2 inner1_p2,
            out Vector2 inner2_p1, out Vector2 inner2_p2)
        {
            // Make sure radius1 <= radius2.
            if (radius1 > radius2)
            {
                // Call this method switching the circles.
                return FindCircleCircleTangents(
                    c2, radius2, c1, radius1,
                    out outer2_p2, out outer2_p1,
                    out outer1_p2, out outer1_p1,
                    out inner1_p2, out inner1_p1,
                    out inner2_p2, out inner2_p1);
            }

            // Initialize the return values in case
            // some tangents are missing.
            outer1_p1 = new Vector2(-1, -1);
            outer1_p2 = new Vector2(-1, -1);
            outer2_p1 = new Vector2(-1, -1);
            outer2_p2 = new Vector2(-1, -1);
            inner1_p1 = new Vector2(-1, -1);
            inner1_p2 = new Vector2(-1, -1);
            inner2_p1 = new Vector2(-1, -1);
            inner2_p2 = new Vector2(-1, -1);

            // ***************************
            // * Find the outer tangents *
            // ***************************
            {
                float radius2a = radius2 - radius1;
                if (!FindTangents(c2, radius2a, c1, out outer1_p2, out outer2_p2))
                {
                    // There are no tangents.
                    return 0;
                }

                // Get the vector perpendicular to the
                // first tangent with length radius1.
                float v1x = -(outer1_p2.y - c1.y);
                float v1y = outer1_p2.x - c1.x;
                float v1_length = (float)Mathf.Sqrt(v1x * v1x + v1y * v1y);
                v1x *= radius1 / v1_length;
                v1y *= radius1 / v1_length;
                // Offset the tangent vector's points.
                outer1_p1 = new Vector2(c1.x + v1x, c1.y + v1y);
                outer1_p2 = new Vector2(outer1_p2.x + v1x, outer1_p2.y + v1y);

                // Get the vector perpendicular to the
                // second tangent with length radius1.
                float v2x = outer2_p2.y - c1.y;
                float v2y = -(outer2_p2.x - c1.x);
                float v2_length = (float)Mathf.Sqrt(v2x * v2x + v2y * v2y);
                v2x *= radius1 / v2_length;
                v2y *= radius1 / v2_length;
                // Offset the tangent vector's points.
                outer2_p1 = new Vector2(c1.x + v2x, c1.y + v2y);
                outer2_p2 = new Vector2(outer2_p2.x + v2x, outer2_p2.y + v2y);
            }

            // If the circles intersect, then there are no inner tangents.
            float dx = c2.x - c1.x;
            float dy = c2.y - c1.y;
            float dist = Mathf.Sqrt(dx * dx + dy * dy);
            if (dist <= radius1 + radius2) return 2;

            // ***************************
            // * Find the inner tangents *
            // ***************************
            {
                float radius1a = radius1 + radius2;
                FindTangents(c1, radius1a, c2, out inner1_p2, out inner2_p2);

                // Get the vector perpendicular to the
                // first tangent with length radius2.
                float v1x = inner1_p2.y - c2.y;
                float v1y = -(inner1_p2.x - c2.x);
                float v1_length = (float)Mathf.Sqrt(v1x * v1x + v1y * v1y);
                v1x *= radius2 / v1_length;
                v1y *= radius2 / v1_length;
                // Offset the tangent vector's points.
                inner1_p1 = new Vector2(c2.x + v1x, c2.y + v1y);
                inner1_p2 = new Vector2(inner1_p2.x + v1x, inner1_p2.y + v1y);

                // Get the vector perpendicular to the
                // second tangent with length radius2.
                float v2x = -(inner2_p2.y - c2.y);
                float v2y = inner2_p2.x - c2.x;
                float v2_length = (float)Mathf.Sqrt(v2x * v2x + v2y * v2y);
                v2x *= radius2 / v2_length;
                v2y *= radius2 / v2_length;
                // Offset the tangent vector's points.
                inner2_p1 = new Vector2(c2.x + v2x, c2.y + v2y);
                inner2_p2 = new Vector2(inner2_p2.x + v2x, inner2_p2.y + v2y);
            }

            return 4;
        }

        // Find the tangent points for this circle and external point.
        // Return true if we find the tangents, false if the point is
        // inside the circle.
        public static bool FindTangents(Vector2 center, float radius,
            Vector2 external_point, out Vector2 pt1, out Vector2 pt2)
        {
            // Find the distance squared from the
            // external point to the circle's center.
            float dx = center.x - external_point.x;
            float dy = center.y - external_point.y;
            float D_squared = dx * dx + dy * dy;
            if (D_squared < radius * radius)
            {
                pt1 = new Vector2(-1, -1);
                pt2 = new Vector2(-1, -1);
                return false;
            }

            // Find the distance from the external point
            // to the tangent points.
            float L = Mathf.Sqrt(D_squared - radius * radius);

            // Find the points of intersection between
            // the original circle and the circle with
            // center external_point and radius dist.
            FindCircleCircleIntersections(
                center.x, center.y, radius,
                external_point.x, external_point.y, (float)L,
                out pt1, out pt2);

            return true;
        }

        // Find the points where the two circles intersect.
        public static int FindCircleCircleIntersections(
            float cx0, float cy0, float radius0,
            float cx1, float cy1, float radius1,
            out Vector2 intersection1, out Vector2 intersection2)
        {
            // Find the distance between the centers.
            float dx = cx0 - cx1;
            float dy = cy0 - cy1;
            float dist = Mathf.Sqrt(dx * dx + dy * dy);

            // See how many solutions there are.
            if (dist > radius0 + radius1)
            {
                // No solutions, the circles are too far apart.
                intersection1 = new Vector2(float.NaN, float.NaN);
                intersection2 = new Vector2(float.NaN, float.NaN);
                return 0;
            }
            else if (dist < Mathf.Abs(radius0 - radius1))
            {
                // No solutions, one circle contains the other.
                intersection1 = new Vector2(float.NaN, float.NaN);
                intersection2 = new Vector2(float.NaN, float.NaN);
                return 0;
            }
            else if ((dist == 0) && (radius0 == radius1))
            {
                // No solutions, the circles coincide.
                intersection1 = new Vector2(float.NaN, float.NaN);
                intersection2 = new Vector2(float.NaN, float.NaN);
                return 0;
            }
            else
            {
                // Find a and h.
                float a = (radius0 * radius0 -
                    radius1 * radius1 + dist * dist) / (2 * dist);
                float h = Mathf.Sqrt(radius0 * radius0 - a * a);

                // Find P2.
                float cx2 = cx0 + a * (cx1 - cx0) / dist;
                float cy2 = cy0 + a * (cy1 - cy0) / dist;

                // Get the points P3.
                intersection1 = new Vector2(
                    (float)(cx2 + h * (cy1 - cy0) / dist),
                    (float)(cy2 - h * (cx1 - cx0) / dist));
                intersection2 = new Vector2(
                    (float)(cx2 - h * (cy1 - cy0) / dist),
                    (float)(cy2 + h * (cx1 - cx0) / dist));

                // See if we have 1 or 2 solutions.
                if (dist == radius0 + radius1) return 1;
                return 2;
            }
        }
}
