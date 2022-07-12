using UnityEngine;

namespace Script.Character
{
    public class PlayerUpdateMoving : MonoBehaviour
    {
        public Vector2 location;
        public Vector2 direction;
        public CharacterState state;
        
        
        private Rigidbody2D rigidbody2d;
        private SpriteRenderer spriteRenderer;
        private bool directionPreference;

        // Start is called before the first frame update
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2d = GetComponent<Rigidbody2D>();
            directionPreference = spriteRenderer.flipX;
        }


        public void FixedUpdate()
        {
            if (((Vector2) transform.position - location).sqrMagnitude > GamePlayProperties.MaxDistance)
            {
                rigidbody2d.MovePosition(location);
                location = rigidbody2d.position;
                spriteRenderer.flipX = direction.x > 0;
            }
            else
            {
                float speed = GetComponent<CharacterScript>().Speed;
                if (!transform.position.Equals(location))
                {
                    var vector2 = location;
                    vector2.x += direction.x * speed * GamePlayProperties.UdpInterval;
                    vector2.y += direction.y * speed * GamePlayProperties.UdpInterval;
                    direction = (vector2 - (Vector2) transform.position) /
                                (speed * GamePlayProperties.UdpInterval);
                }
                if (directionPreference)
                {
                    spriteRenderer.flipX = !(direction.x > 0);
                }
                else
                {
                    spriteRenderer.flipX = (direction.x > 0);
                }

                var position = rigidbody2d.position;

                position.x += direction.x * speed * Time.deltaTime;
                position.y += direction.y * speed * Time.deltaTime;

                rigidbody2d.MovePosition(position);
                location = rigidbody2d.position;
            }
        }
    }
}