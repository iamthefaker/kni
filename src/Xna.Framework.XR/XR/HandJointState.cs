// Copyright (C)2024 Nick Kastellanos

using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.XR
{
    /// <summary>
    /// Contains tracking data for a single hand joint.
    /// </summary>
    public struct HandJointState
    {
        /// <summary>
        /// The position and orientation of the joint in tracking space.
        /// </summary>
        public Pose3 Pose;

        /// <summary>
        /// The radius of the joint sphere, useful for collision detection.
        /// </summary>
        public float Radius;

        /// <summary>
        /// The linear velocity of the joint in meters per second.
        /// </summary>
        public Vector3 LinearVelocity;

        /// <summary>
        /// The angular velocity of the joint in radians per second.
        /// </summary>
        public Vector3 AngularVelocity;

        /// <summary>
        /// Indicates whether this joint's tracking data is valid.
        /// </summary>
        public bool IsValid;

        /// <summary>
        /// Returns a transformation matrix for this joint.
        /// </summary>
        public Matrix GetTransform()
        {
            return Matrix.CreateFromPose(Pose);
        }
    }
}
