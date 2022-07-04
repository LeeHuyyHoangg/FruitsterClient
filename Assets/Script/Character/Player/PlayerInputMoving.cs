using Script;
using UnityEngine;

public class PlayerInputMoving : MonoBehaviour
{
    private FixedJoystick fixedJoystick;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
    }

    private void FixedUpdate()
    {
        var charState = GetComponent<CharacterScript>()?.state;
        if (charState != null && charState != CharacterState.Hitted && charState != CharacterState.Chatting)
        {
            var joyStickDirection = fixedJoystick.Direction;
            if (joyStickDirection.x != 0 && joyStickDirection.y != 0)
            {
                spriteRenderer.flipX = joyStickDirection.x > 0;

                var position = rigidbody2D.position;

                position.x += joyStickDirection.x * GamePlayProperties.Speed * Time.deltaTime;
                position.y += joyStickDirection.y * GamePlayProperties.Speed * Time.deltaTime;

                rigidbody2D.MovePosition(position);
                GetComponent<CharacterScript>().state = CharacterState.Moving;
            }
            else
            {
                GetComponent<CharacterScript>().state = CharacterState.Idle;

            }
        }
    }
}