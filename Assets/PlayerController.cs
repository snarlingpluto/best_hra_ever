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
    //barvy
    private Color Color1;
    private Color Color2;
    //ui
    public Image slot1;
    public Image slot2;
    //prazdna a plna krabice
    public Sprite empty;
    public Sprite full;
    //policka 1
    public GameObject shelf1;
    private SpriteRenderer sprite_Renderer1;
    //policka 2
    public GameObject shelf2;
    private SpriteRenderer sprite_Renderer2;


    void OnTriggerEnter2D(Collider2D collision)
    {
        //zmena mistnosti
        if (collision.CompareTag("RoomTransport"))
        {
            camera1.transform.position = collision.transform.position + new Vector3(0,0,-10);
            camera1.transform.position = collision.transform.position + new Vector3(0, 0, -10);
        }
        
        //nabirani krabice
        if (collision.CompareTag("Crate1"))
        {
            Destroy(collision.gameObject);
            slot1.sprite = full;
            slot1.color = Color.white;
        }
        if (collision.CompareTag("Crate2"))
        {
            Destroy(collision.gameObject);
            slot2.sprite = full;
            slot2.color = Color.white;
        }
        //odevzdani krabice
       if (collision.CompareTag("Blue") && slot1.sprite == full)
        {
            slot1.sprite = empty;
            sprite_Renderer2 = collision.GetComponent<SpriteRenderer>();
            sprite_Renderer2.sprite = full;
            sprite_Renderer2.color = Color.white;

        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //nastaveni barev pro kazdy box
        Color1 = Color.blue;
        Color2 = Color.green;
        //box 1 
        sprite_Renderer1 = shelf1.GetComponent<SpriteRenderer>();
        slot1.sprite = empty;
        sprite_Renderer1.color = Color1;
        slot1.color = Color1;
        //box 2
        sprite_Renderer2 = shelf2.GetComponent<SpriteRenderer>();
        slot2.sprite = empty;
        sprite_Renderer2.color = Color2;
        slot2.color = Color2;
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