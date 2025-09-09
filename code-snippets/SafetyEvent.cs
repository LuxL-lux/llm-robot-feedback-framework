public SafetyEvent(string monitorName, SafetyEventType eventType, string description, RobotState currentState)
{
    this.monitorName = monitorName;
    this.eventType = eventType;
    this.description = description;
    this.timestamp = DateTime.Now;
    this.robotStateSnapshot = currentState != null ? new RobotStateSnapshot(currentState) : null;
}
