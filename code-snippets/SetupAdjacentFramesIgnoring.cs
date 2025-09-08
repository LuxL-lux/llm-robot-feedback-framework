private void SetupAdjacentFrameIgnoring()
{
    // Dynamically ignore collisions between adjacent frames in the kinematic chain
    Frame[] frames = GetComponentsInChildren<Frame>();
    
    // Sortieren der Hierachie der Frame
    System.Array.Sort(frames, (a, b) => GetHierarchyDepth(a.transform).CompareTo(GetHierarchyDepth(b.transform)));

    for (int i = 0; i < frames.Length - 1; i++)
    {
        Transform currentFrame = frames[i].transform;
        Transform nextFrame = frames[i + 1].transform;
        // Methode sucht nach Collidern im GameObject und setzt
        // Physics.IgnoreCollision
        IgnoreCollisionsBetweenParts(currentFrame, nextFrame);
    }
}

