using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class SlotManagerColorSprites : MonoBehaviour
{
    [Header("Slot GameObjects (16)")]
    public GameObject[] slotObjects = new GameObject[16];

    [Header("Color Sprites")]
    public Sprite spriteRed;
    public Sprite spriteGreen;
    public Sprite spriteBlue;
    public Sprite spriteYellow;
    public Sprite spritePurple;
    public Sprite spriteOrange;
    public Sprite spriteCyan;
    public Sprite spriteMagenta;

    [Header("Empty Sprite")]
    public Sprite emptySprite;

    private Sprite[] assignedSprites = new Sprite[16];

    void Start()
    {
        AssignRandomSprites();
        ApplySpriteBehaviors();
    }

    void AssignRandomSprites()
    {
        List<Sprite> sprites = new List<Sprite>
        {
            spriteRed,
            spriteGreen,
            spriteBlue,
            spriteYellow,
            spritePurple,
            spriteOrange,
            spriteCyan,
            spriteMagenta
        };

        for (int i = 0; i < 8; i++)
        {
            sprites.Add(emptySprite);
        }

        sprites = sprites.OrderBy(s => Random.value).ToList();

        for (int i = 0; i < 16; i++)
        {
            assignedSprites[i] = sprites[i];
        }
    }

    void ApplySpriteBehaviors()
    {
        for (int i = 0; i < 16; i++)
        {
            GameObject slot = slotObjects[i];
            Sprite sprite = assignedSprites[i];

            SpriteRenderer renderer = slot.GetComponent<SpriteRenderer>();
            if (renderer != null)
            {
                renderer.sprite = sprite;
            }

            // Tag assignment based on sprite
            if (sprite == emptySprite)
            {
                slot.tag = "Empty";
                Debug.Log($"Slot {i + 1} is Empty.");
            }
            else if (sprite == spriteRed)
            {
                slot.tag = "Red";
                Debug.Log($"Slot {i + 1} is Red.");
            }
            else if (sprite == spriteGreen)
            {
                slot.tag = "Green";
                Debug.Log($"Slot {i + 1} is Green.");
            }
            else if (sprite == spriteBlue)
            {
                slot.tag = "Blue";
                Debug.Log($"Slot {i + 1} is Blue.");
            }
            else if (sprite == spriteYellow)
            {
                slot.tag = "Yellow";
                Debug.Log($"Slot {i + 1} is Yellow.");
            }
            else if (sprite == spritePurple)
            {
                slot.tag = "Purple";
                Debug.Log($"Slot {i + 1} is Purple.");
            }
            else if (sprite == spriteOrange)
            {
                slot.tag = "Orange";
                Debug.Log($"Slot {i + 1} is Orange.");
            }
            else if (sprite == spriteCyan)
            {
                slot.tag = "Cyan";
                Debug.Log($"Slot {i + 1} is Cyan.");
            }
            else if (sprite == spriteMagenta)
            {
                slot.tag = "Magenta";
                Debug.Log($"Slot {i + 1} is Magenta.");
            }
            else
            {
                slot.tag = "Untagged";
                Debug.LogWarning($"Slot {i + 1} has an unknown sprite.");
            }
        }
    }
}