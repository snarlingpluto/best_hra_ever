using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SlotManagerColorSprites : MonoBehaviour
{
    public int cratesPerScene = 8;
    public int palletes = 15;

    [Header("Slot GameObjects (max 15)")]
    public GameObject[] slotObjects = new GameObject[15];

    [Header("Color Sprites")]
    public Sprite spriteRed;
    public Sprite spriteGreen;
    public Sprite spriteBlue;
    public Sprite spriteYellow;
    public Sprite spriteOrange;
    public Sprite spriteWhite;
    public Sprite spriteCyan;
    public Sprite spritePink;

    [Header("Empty Sprite")]
    public Sprite emptySprite;

    private Sprite[] assignedSprites;

    void Start()
    {
        int total = slotObjects.Length;
        assignedSprites = new Sprite[total];

        AssignColorSpritesRandomized();
        ApplySpriteBehaviors();
    }

    void AssignColorSpritesRandomized()
    {
        int crateCount = Mathf.Clamp(GameStats.level, 1, assignedSprites.Length);
        if (GameStats.level < 5)
        {
            crateCount = GameStats.level * 2;
        }
        else
        {
            crateCount = 8;
        }
        GameStats.cratesToBeDelivered = crateCount;
        
        List<Sprite> availableColors = new List<Sprite>
        {
            spriteRed, spriteGreen, spriteBlue,
            spriteYellow, spriteOrange, spriteWhite,
            spriteCyan, spritePink
        };

        availableColors = availableColors.OrderBy(_ => Random.value).ToList();

        // vybereme přesně "count" barev (opakované, pokud potřeba)
        List<Sprite> chosen = new List<Sprite>();
        for (int i = 0; i < crateCount; i++)
            chosen.Add(availableColors[i % availableColors.Count]);

        // vytvoříme seznam všech indexů a zamícháme
        List<int> allIndexes = Enumerable.Range(0, assignedSprites.Length).OrderBy(_ => Random.value).ToList();

        // přiřadíme do přiřazených slotů na prvních count pozicích
        for (int i = 0; i < assignedSprites.Length; i++)
            assignedSprites[i] = emptySprite;

        for (int i = 0; i < crateCount; i++)
        {
            int slotIndex = allIndexes[i];
            assignedSprites[slotIndex] = chosen[i];
        }
    }

    void ApplySpriteBehaviors()
    {
        for (int i = 0; i < slotObjects.Length; i++)
        {
            GameObject slot = slotObjects[i];
            SpriteRenderer ren = slot.GetComponent<SpriteRenderer>();
            Sprite s = assignedSprites[i];

            if (ren != null)
                ren.sprite = s;

            if (s == emptySprite)
                slot.tag = "Empty";
            else if (s == spriteRed)
                slot.tag = "Red";
            else if (s == spriteGreen)
                slot.tag = "Green";
            else if (s == spriteBlue)
                slot.tag = "Blue";
            else if (s == spriteYellow)
                slot.tag = "Yellow";
            else if (s == spriteOrange)
                slot.tag = "Orange";
            else if (s == spriteWhite)
                slot.tag = "White";
            else if (s == spriteCyan)
                slot.tag = "Cyan";
            else if (s == spritePink)
                slot.tag = "Pink";
            else
                slot.tag = "Untagged";

            Debug.Log($"Slot {i + 1}: sprite = {(s == emptySprite ? "Empty" : s.name)}, tag = {slot.tag}");
        }
    }
}
