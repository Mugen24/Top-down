using UnityEngine;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float rotationSpeed = 200f;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    private Vector2 movement;
    private float colorChangeInterval = 1f;
    private float colorChangeTimer;

    private Color[] colors = { Color.white, Color.red, Color.blue };

    public bool blockControl;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        colorChangeTimer = colorChangeInterval;
        ChangeColor();
    }

    void Update()
    {
        HandleMovementInput();
        HandleColorChange();
    }

    void FixedUpdate()
    {
        //Prevent player from moving while other actions is in progres
        if (blockControl) { return; }
        //Debug.Log(blockControl);
        MoveAndRotatePlayer();
    }

    private void HandleMovementInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void MoveAndRotatePlayer()
    {
        if (movement != Vector2.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(Vector3.forward, movement);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.fixedDeltaTime);
        }

        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    private void HandleColorChange()
    {
        colorChangeTimer -= Time.deltaTime;
        if (colorChangeTimer <= 0)
        {
            ChangeColor();
            colorChangeTimer = colorChangeInterval;
        }
    }

    private void ChangeColor()
    {
        Color newColor = colors[Random.Range(0, colors.Length)];
        spriteRenderer.color = newColor;
    }

/*
    public IEnumerator SkillDash() {
        if (!isDashable) { yield break; }

        isDashable = false;
        _isDashing = true;

        //rb.AddForce(transform.up * dashMultiplier, ForceMode2D.Impulse);
        rb.velocity = transform.up * dashMultiplier;

        yield return new WaitForSeconds(_dashTimeSecond);
        _isDashing = false;

        yield return new WaitForSeconds(dashCoolDownSecond);
        isDashable = true;

    
    }
*/

}

