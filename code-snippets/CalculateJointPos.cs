private Vector3 ComputeJointPosition(float[] jointAngles, int jointIndex)
{
    Matrix4x4 baseTransform = Matrix4x4.identity;

    // Apply joint transformations to get to desired joint position
    // To get joint N position, apply transformations 0 to N-1
    for (int i = 0; i < jointIndex - 1 && i < robotFrames.Length - 1; i++)
    {
        var frame = robotFrames[i + 1]; // Frame i+1 corresponds to joint i
        var config = frame.Config;

        // Create transformation matrix using DH parameters
        float theta = jointAngles[i] * Mathf.Deg2Rad + config.Theta;
        Matrix4x4 dhTransform = HomogeneousMatrix.CreateRaw(new FrameConfig(
            config.Alpha, config.A, config.D, theta
        ));

        baseTransform = baseTransform * dhTransform;
    }

    return baseTransform.GetPosition();
}
