using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed;
    public bool movementAllowed = true;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Camera mainCamera;

    public Image slotBlue;
    public Image slotGreen;
    public Image slotWhite;
    public Image slotPink;
    public Image slotRed;
    public Image slotCyan;
    public Image slotYellow;
    public Image slotOrange;

    public Sprite crateBlue;
    public Sprite crateGreen;
    public Sprite crateYellow;
    public Sprite crateCyan;
    public Sprite cratePink;
    public Sprite crateOrange;
    public Sprite crateWhite;
    public Sprite crateRed;
    public Sprite empty;

    private SpriteRenderer sprite_RendererBlue;
    private SpriteRenderer sprite_RendererWhite;
    private SpriteRenderer sprite_RendererCyan;
    private SpriteRenderer sprite_RendererGreen;
    private SpriteRenderer sprite_RendererRed;
    private SpriteRenderer sprite_RendererYellow;
    private SpriteRenderer sprite_RendererPurple;
    private SpriteRenderer sprite_RendererPink;

    // ✅ crate tracking
    private int currentCrates = 0;
    public const int maxCrates = 4;

    private Dictionary<string, Image> slotMap;
    private Dictionary<string, Sprite> crateMap;
    private Dictionary<string, System.Action<Collider2D>> spriteSetters;

    private void Start()
    {
        mainCamera = FindAnyObjectByType<Camera>();
        rb = GetComponent<Rigidbody2D>();

        slotMap = new Dictionary<string, Image> {
            { "Blue", slotBlue },
            { "Green", slotGreen },
            { "White", slotWhite },
            { "Pink", slotPink },
            { "Red", slotRed },
            { "Cyan", slotCyan },
            { "Yellow", slotYellow },
            { "Orange", slotOrange }
        };

        crateMap = new Dictionary<string, Sprite> {
            { "Blue", crateBlue },
            { "Green", crateGreen },
            { "White", crateWhite },
            { "Pink", cratePink },
            { "Red", crateRed },
            { "Cyan", crateCyan },
            { "Yellow", crateYellow },
            { "Orange", crateOrange }
        };

        spriteSetters = new Dictionary<string, System.Action<Collider2D>> {
            { "Blue", col => sprite_RendererBlue = col.GetComponent<SpriteRenderer>() },
            { "Green", col => sprite_RendererGreen = col.GetComponent<SpriteRenderer>() },
            { "White", col => sprite_RendererWhite = col.GetComponent<SpriteRenderer>() },
            { "Pink", col => sprite_RendererPink = col.GetComponent<SpriteRenderer>() },
            { "Red", col => sprite_RendererRed = col.GetComponent<SpriteRenderer>() },
            { "Cyan", col => sprite_RendererCyan = col.GetComponent<SpriteRenderer>() },
            { "Yellow", col => sprite_RendererYellow = col.GetComponent<SpriteRenderer>() },
            { "Orange", col => sprite_RendererPurple = col.GetComponent<SpriteRenderer>() }
        };

        foreach (var kvp in slotMap)
        {
            kvp.Value.sprite = empty;
            kvp.Value.color = GetSlotColor(kvp.Key);
        }

        currentCrates = 0;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("RoomTransport"))
        {
            mainCamera.transform.position = collision.transform.position + new Vector3(0, 0, -10);
            return;
        }

        foreach (var color in slotMap.Keys)
        {
            // ✅ PICKUP logic
            if (collision.CompareTag($"Crate{color}"))
            {
                if (currentCrates >= maxCrates || slotMap[color].sprite != empty)
                    return;

                Destroy(collision.gameObject);
                slotMap[color].sprite = crateMap[color];
                slotMap[color].color = Color.white;
                currentCrates++;
                return;
            }

            // ✅ DELIVERY logic
            if (collision.CompareTag(color) && slotMap[color].sprite == crateMap[color])
            {
                slotMap[color].sprite = empty;
                slotMap[color].color = GetSlotColor(color);
                spriteSetters[color](collision);
                SpriteRenderer renderer = collision.GetComponent<SpriteRenderer>();
                renderer.sprite = crateMap[color];
                renderer.color = Color.white;
                currentCrates--;
                return;
            }
        }
    }

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        movement = movement.normalized;

        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }
    }
    public void toggleMovement()
    {
        if (movementAllowed)
        {
            movementAllowed = false;
        }
        else
        {
            movementAllowed = true;
        }
    }

    void FixedUpdate()
    {
        if (movementAllowed)
        {
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }

    // ✅ Utility to restore slot color
    private Color GetSlotColor(string color)
    {
        return color switch
        {
            "Blue" => Color.blue,
            "Green" => Color.green,
            "White" => Color.white,
            "Pink" => Color.magenta,
            "Red" => Color.red,
            "Cyan" => Color.cyan,
            "Yellow" => Color.yellow,
            "Orange" => new Color(0.5f, 0f, 0.5f),
            _ => Color.gray
        };
    }
}

