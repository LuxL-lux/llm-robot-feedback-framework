public RobotStateSnapshot(RobotState state)
{
    if (state != null)
    {
        captureTime = DateTime.Now;
        // Program info
        isProgramRunning = state.isRunning;
        currentModule = state.currentModule ?? "";
        currentRoutine = state.currentRoutine ?? "";
        currentLine = state.currentLine;
        currentColumn = state.currentColumn;
        executionCycle = state.executionCycle ?? "";
        motorState = state.motorState ?? "";
        controllerState = state.controllerState ?? "";
        // Abrufen der aktuellen Achswinkel
        jointAngles = state.GetJointAngles();
        hasValidJointData = state.hasValidJointData;
        motionUpdateFrequencyHz = state.motionUpdateFrequencyHz;
        // IO Signale
        gripperOpen = state.GripperOpen;
        // Verbindungsinformationen
        robotType = state.robotType ?? "";
        robotIP = state.robotIP ?? "";
    }
}
