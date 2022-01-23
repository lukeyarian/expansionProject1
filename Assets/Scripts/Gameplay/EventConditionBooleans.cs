using UnityEngine;

/// <summary>
/// Keep all public booleans here for events and items etc for efficiency (architecturally change this in the future)
/// </summary>
public static class EventConditionBooleans
{
    public static bool HasUserTalkedToDoorOnFirstRoom = false;
    public static bool HasUsedTheClock = false;
    public static bool HasInteractedWithWindow = false;
    public static bool HasFinishedInteractionWithPlant = false;
    public static bool HasFinishedInteractionWithSphere = false;
    public static bool HasGivenFsitToWindow = false;
}
