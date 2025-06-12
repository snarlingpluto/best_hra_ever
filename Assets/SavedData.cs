using UnityEngine;

public static class GameStats
{
    public static int cratesDelivered { get; set; }
    public static int level { get; set; } = 1;
    public static int maxLevel { get; set; }
    public static bool gameLoss { get; set; } = false;
    public static bool firstLoad { get; set; } = true;
    public static bool movementAllowed { get; set; } = true;
    public static bool cooldown { get; set; } = false;
    public static bool mainMenuOpen { get; set; } = true;
}
