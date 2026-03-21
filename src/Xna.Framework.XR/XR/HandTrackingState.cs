// Copyright (C)2024 Nick Kastellanos

using System;
using System.Collections.Generic;

namespace Microsoft.Xna.Framework.XR
{
    /// <summary>
    /// Contains the complete hand tracking state for both hands.
    /// </summary>
    public struct HandTrackingState
    {
        /// <summary>
        /// The number of joints tracked per hand (26 in OpenXR).
        /// </summary>
        public const int JointCount = 26;

        private HandJointState[] _leftJoints;
        private HandJointState[] _rightJoints;

        /// <summary>
        /// Indicates whether the left hand is currently being tracked.
        /// </summary>
        public bool IsLeftHandTracked;

        /// <summary>
        /// Indicates whether the right hand is currently being tracked.
        /// </summary>
        public bool IsRightHandTracked;

        /// <summary>
        /// Gets the joint states for the left hand.
        /// </summary>
        public HandJointState[] LeftJoints
        {
            get { return _leftJoints; }
            set { _leftJoints = value; }
        }

        /// <summary>
        /// Gets the joint states for the right hand.
        /// </summary>
        public HandJointState[] RightJoints
        {
            get { return _rightJoints; }
            set { _rightJoints = value; }
        }

        /// <summary>
        /// Gets the state of a specific joint on the specified hand.
        /// </summary>
        /// <param name="handIndex">0 for left hand, 1 for right hand.</param>
        /// <param name="joint">The joint to retrieve.</param>
        /// <returns>The joint state.</returns>
        public HandJointState GetJoint(int handIndex, HandJoint joint)
        {
            switch (handIndex)
            {
                case 0:
                    return GetLeftJoint(joint);
                case 1:
                    return GetRightJoint(joint);
                default:
                    throw new IndexOutOfRangeException("handIndex must be 0 (left) or 1 (right)");
            }
        }

        /// <summary>
        /// Gets the state of a specific joint on the left hand.
        /// </summary>
        public HandJointState GetLeftJoint(HandJoint joint)
        {
            if (_leftJoints == null)
                return default;
            return _leftJoints[(int)joint];
        }

        /// <summary>
        /// Gets the state of a specific joint on the right hand.
        /// </summary>
        public HandJointState GetRightJoint(HandJoint joint)
        {
            if (_rightJoints == null)
                return default;
            return _rightJoints[(int)joint];
        }

        /// <summary>
        /// Gets the transformation matrix for a specific joint.
        /// </summary>
        /// <param name="handIndex">0 for left hand, 1 for right hand.</param>
        /// <param name="joint">The joint to retrieve.</param>
        /// <returns>The joint transformation matrix.</returns>
        public Matrix GetJointTransform(int handIndex, HandJoint joint)
        {
            HandJointState jointState = GetJoint(handIndex, joint);
            return Matrix.CreateFromPose(jointState.Pose);
        }

        /// <summary>
        /// Checks whether a specific hand is tracked.
        /// </summary>
        /// <param name="handIndex">0 for left hand, 1 for right hand.</param>
        /// <returns>True if the hand is tracked.</returns>
        public bool IsHandTracked(int handIndex)
        {
            switch (handIndex)
            {
                case 0:
                    return IsLeftHandTracked;
                case 1:
                    return IsRightHandTracked;
                default:
                    throw new IndexOutOfRangeException("handIndex must be 0 (left) or 1 (right)");
            }
        }

        /// <summary>
        /// Initializes the joint arrays. Call this before populating joint data.
        /// </summary>
        public void Initialize()
        {
            if (_leftJoints == null)
                _leftJoints = new HandJointState[JointCount];
            if (_rightJoints == null)
                _rightJoints = new HandJointState[JointCount];
        }

        /// <summary>
        /// Sets the state of a specific joint on the left hand.
        /// </summary>
        /// <param name="jointIndex">The joint index (0-25).</param>
        /// <param name="state">The joint state to set.</param>
        public void SetLeftJoint(int jointIndex, HandJointState state)
        {
            if (_leftJoints != null && jointIndex >= 0 && jointIndex < JointCount)
                _leftJoints[jointIndex] = state;
        }

        /// <summary>
        /// Sets the state of a specific joint on the right hand.
        /// </summary>
        /// <param name="jointIndex">The joint index (0-25).</param>
        /// <param name="state">The joint state to set.</param>
        public void SetRightJoint(int jointIndex, HandJointState state)
        {
            if (_rightJoints != null && jointIndex >= 0 && jointIndex < JointCount)
                _rightJoints[jointIndex] = state;
        }
    }
}
