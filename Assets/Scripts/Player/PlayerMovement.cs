using System.Runtime.CompilerServices;
using Unity.VisualScripting.ReorderableList;
using UnityEngine;


public class PlayerMovement : MonoBehaviour
{
    [Header("Config")]
    [SerializeField] private float speed;
    private InputActions actions;
    private Rigidbody2D rigidBody2d;
    private Vector2 moveDirection;
    private Animator animator;
    private PlayerAnimation playerAnimations;
    private Player player;
    
    
    private void ReadMovement()
    {
        moveDirection = actions.Movement.Move.ReadValue<Vector2>().normalized;

        

        if (moveDirection == Vector2.zero)
        { 
            playerAnimations.SetMoveBoolTransition(false);
            
            return;
        }

        playerAnimations.SetMoveBoolTransition(true);
        playerAnimations.SetMoveAnimation(moveDirection);

    }

    private void Move()
    {
        if (player.Stats.health <= 0)
        {
            return;
        }
        rigidBody2d.MovePosition(rigidBody2d.position + moveDirection * (speed * Time.fixedDeltaTime));
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Awake()
    {
        animator = GetComponent<Animator>();
        actions = new InputActions();
        rigidBody2d = GetComponent<Rigidbody2D>();
        playerAnimations = GetComponent<PlayerAnimation>();
        player = GetComponent<Player>();
    }

    private void OnEnable()
    {
        actions.Enable();
    }

    private void OnDisable()
    {
        actions.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        ReadMovement();
    }
}
