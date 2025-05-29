using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
public class TopDownMovement : MonoBehaviour
{
    //pohyb hrace
    public float moveSpeed = 5f;
    public float rotationSpeed;

    private Rigidbody2D rb;
    private Vector2 movement;
    //prepinani kamery
    public Camera camera1;
    //ui
    public Image slotBlue;
    public Image slotGreen;
    public Image slotWhite;
    public Image slotPink;
    public Image slotRed;
    public Image slotCyan;
    public Image slotYellow;
    public Image slotPurple;
    //prazdna a plna krabice
    public Sprite crateBlue;
    public Sprite crateGreen;
    public Sprite crateYellow;
    public Sprite crateCyan;
    public Sprite cratePink;
    public Sprite cratePurple;
    public Sprite crateWhite;
    public Sprite crateRed;
    public Sprite empty;
    //sprite renderers
    private SpriteRenderer sprite_RendererBlue;
    private SpriteRenderer sprite_RendererWhite;
    private SpriteRenderer sprite_RendererCyan;
    private SpriteRenderer sprite_RendererGreen;
    private SpriteRenderer sprite_RendererRed;
    private SpriteRenderer sprite_RendererYellow;
    private SpriteRenderer sprite_RendererPurple;
    private SpriteRenderer sprite_RendererPink;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //zmena mistnosti
        if (collision.CompareTag("RoomTransport"))
        {
            camera1.transform.position = collision.transform.position + new Vector3(0, 0, -10);
        }

        //nabirani krabice
        if (collision.CompareTag("CrateBlue"))
        {
            Destroy(collision.gameObject);
            slotBlue.sprite = crateBlue;
            slotBlue.color = Color.white;
        }
        if (collision.CompareTag("CrateGreen"))
        {
            Destroy(collision.gameObject);
            slotGreen.sprite = crateGreen;
            slotGreen.color = Color.white;
        }
        if (collision.CompareTag("CrateWhite"))
        {
            Destroy(collision.gameObject);
            slotWhite.sprite = crateWhite;
            slotWhite.color = Color.white;
        }
        if (collision.CompareTag("CratePink"))
        {
            Destroy(collision.gameObject);
            slotPink.sprite = cratePink;
            slotPink.color = Color.white;
        }
        if (collision.CompareTag("CrateYellow"))
        {
            Destroy(collision.gameObject);
            slotYellow.sprite = crateYellow;
            slotYellow.color = Color.white;
        }
        if (collision.CompareTag("CrateCyan"))
        {
            Destroy(collision.gameObject);
            slotCyan.sprite = crateCyan;
            slotCyan.color = Color.white;
        }
        if (collision.CompareTag("CratePurple"))
        {
            Destroy(collision.gameObject);
            slotPurple.sprite = cratePurple;
            slotPurple.color = Color.white;
        }
        if (collision.CompareTag("CrateRed"))
        {
            Destroy(collision.gameObject);
            slotRed.sprite = crateRed;
            slotRed.color = Color.white;
        }


        //odevzdani krabice
        if (collision.CompareTag("Blue") && slotBlue.sprite == crateBlue)
        {
            slotBlue.sprite = empty;
            sprite_RendererBlue = collision.GetComponent<SpriteRenderer>();
            sprite_RendererBlue.sprite = crateBlue;
            sprite_RendererBlue.color = Color.white;
        }
        if (collision.CompareTag("Cyan") && slotCyan.sprite == crateCyan)
        {
            slotCyan.sprite = empty;
            sprite_RendererCyan = collision.GetComponent<SpriteRenderer>();
            sprite_RendererCyan.sprite = crateCyan;
            sprite_RendererCyan.color = Color.white;
        }
        if (collision.CompareTag("Green") && slotGreen.sprite == crateGreen)
        {
            slotGreen.sprite = empty;
            sprite_RendererGreen = collision.GetComponent<SpriteRenderer>();
            sprite_RendererGreen.sprite = crateGreen;
            sprite_RendererGreen.color = Color.white;
        }
        if (collision.CompareTag("Purple") && slotPurple.sprite == cratePurple)
        {
            slotPurple.sprite = empty;
            sprite_RendererPurple = collision.GetComponent<SpriteRenderer>();
            sprite_RendererPurple.sprite = cratePurple;
            sprite_RendererPurple.color = Color.white;
        }
        if (collision.CompareTag("Red") && slotRed.sprite == crateRed)
        {
            slotRed.sprite = empty;
            sprite_RendererRed = collision.GetComponent<SpriteRenderer>();
            sprite_RendererRed.sprite = crateRed;
            sprite_RendererRed.color = Color.white;
        }
        if (collision.CompareTag("White") && slotWhite.sprite == crateWhite)
        {
            slotWhite.sprite = empty;
            sprite_RendererWhite = collision.GetComponent<SpriteRenderer>();
            sprite_RendererWhite.sprite = crateWhite;
            sprite_RendererWhite.color = Color.white;
        }
        if (collision.CompareTag("Pink") && slotPink.sprite == cratePink)
        {
            slotPink.sprite = empty;
            sprite_RendererPink = collision.GetComponent<SpriteRenderer>();
            sprite_RendererPink.sprite = cratePink;
            sprite_RendererPink.color = Color.white;
        }
        if (collision.CompareTag("Yellow") && slotYellow.sprite == crateYellow)
        {
            slotYellow.sprite = empty;
            sprite_RendererYellow = collision.GetComponent<SpriteRenderer>();
            sprite_RendererYellow.sprite = crateYellow;
            sprite_RendererYellow.color = Color.white;

        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        slotBlue.sprite = empty;
        slotBlue.color = Color.blue;

        slotGreen.sprite = empty;
        slotGreen.color = Color.green;

        slotCyan.color = Color.cyan;
        slotCyan.sprite = empty;

        slotPink.color = Color.magenta;
        slotPink.sprite = empty;

        slotPurple.color = new Color(0.5f, 0f, 0.5f);
        slotPurple.sprite = empty;

        slotRed.color = Color.red;
        slotRed.sprite = empty;

        slotWhite.color = Color.white;
        slotWhite.sprite = empty;

        slotYellow.color = Color.yellow;
        slotYellow.sprite = empty;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        movement.y = Input.GetAxisRaw("Vertical");   // W/S or Up/Down
        movement = movement.normalized; // To prevent faster diagonal movement

        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

    }

    void FixedUpdate()
    {
        // Apply movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}