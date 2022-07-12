
using Script;
using Script.Messages.CsMessages;
using Script.Utils;
using UnityEngine;

public class PlayerInputMoving : MonoBehaviour
{
    private FixedJoystick fixedJoystick;
    private new Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private bool directionPreference;

    private long lastSendServerLocation = TimeUtils.CurrentTimeMillis();

    private UdpConnect serverUdpConnection;

    // Start is called before the first frame update
    private void Start()
    {
        serverUdpConnection = new UdpConnect(AppProperties.ServerIp, AppProperties.ServerUdpPort);
         
        spriteRenderer = GetComponent<SpriteRenderer>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        fixedJoystick = GameObject.Find("Fixed Joystick").GetComponent<FixedJoystick>();
        directionPreference = spriteRenderer.flipX;
    }

    private void FixedUpdate()
    {
        var charState = GetComponent<CharacterScript>()?.state;
        if (charState != null && charState != CharacterState.Hitted && charState != CharacterState.Chatting)
        {
            var joyStickDirection = fixedJoystick.Direction;
            if (joyStickDirection.x != 0 && joyStickDirection.y != 0)
            {
                if (directionPreference)
                {
                    spriteRenderer.flipX = !(joyStickDirection.x > 0);
                }
                else
                {
                    spriteRenderer.flipX = (joyStickDirection.x > 0);
                }

                var position = rigidbody2D.position;

                position.x += joyStickDirection.x * GetComponent<CharacterScript>().Speed * Time.deltaTime;
                position.y += joyStickDirection.y * GetComponent<CharacterScript>().Speed * Time.deltaTime;

                rigidbody2D.MovePosition(position);
                GetComponent<CharacterScript>().state = CharacterState.Moving;
            }
            else
            {
                GetComponent<CharacterScript>().state = CharacterState.Idle;

            }
        }

        if (lastSendServerLocation + GamePlayProperties.UdpInterval < TimeUtils.CurrentTimeMillis())
        {
            serverUdpConnection.Send(new CsCharacterState(UserProperties.MainPlayer.userID, transform.position, fixedJoystick.Direction, GetComponent<CharacterScript>().state));
            
            lastSendServerLocation = TimeUtils.CurrentTimeMillis();
        }
    }
}