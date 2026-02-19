using UnityEngine;
using UnityEngine.InputSystem;

public class TwoPlayersOneKeyboard : MonoBehaviour
{

    [Header("Actions (drag from your Input Actions Asset)")]
    [SerializeField] private InputActionReference p1Move;
    [SerializeField] private InputActionReference p2Move;
    [SerializeField] private InputActionReference p1Jump;
    [SerializeField] private InputActionReference p2Jump;

    [Header("Players")]
    [SerializeField] private Transform p1;
    [SerializeField] private Transform p2;

    private Rigidbody rb1;
    private Rigidbody rb2;

    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpHeight = 3f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void Start()
    {
        rb1 = p1.GetComponent<Rigidbody>();
        rb2 = p2.GetComponent<Rigidbody>();
    }

    private void OnEnable()
    {
        p1Move.action.Enable();
        p2Move.action.Enable();

        p1Jump.action.Enable();
        p2Jump.action.Enable();
    }

    private void OnDisable()
    {
        p1Move.action.Disable();
        p2Move.action.Disable();

        p1Jump.action.Disable();
        p2Jump.action.Disable();
    }

    void Update()
    {
        var m1 = p1Move.action.ReadValue<Vector2>();
        var m2 = p2Move.action.ReadValue<Vector2>();

        if (p1) p1.position += new Vector3(m1.x, 0f, m1.y) * speed * Time.deltaTime;
        if (p2) p2.position += new Vector3(m2.x, 0f, m2.y) * speed * Time.deltaTime;

        var j1 = p1Jump.action.ReadValue<float>();
        if (j1 > 0f)
        {
            P1Jump();
        }

        var j2 = p2Jump.action.ReadValue<float>();
        if (j2 > 0f)
        {
            P2Jump();
        }
    }

    public void P1Jump()
    {
        rb1.linearVelocity = new Vector3(rb1.linearVelocity.x, jumpHeight, rb1.linearVelocity.z);
    }

    public void P2Jump()
    {
        rb2.linearVelocity = new Vector3(rb2.linearVelocity.x, jumpHeight, rb2.linearVelocity.z);
    }
}
