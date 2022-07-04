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

        // Start is called before the first frame update
        private void Start()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            rigidbody2d = GetComponent<Rigidbody2D>();
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
                if (!transform.position.Equals(location))
                {
                    var vector2 = location;
                    vector2.x += direction.x * GamePlayProperties.Speed * GamePlayProperties.UdpInterval;
                    vector2.y += direction.y * GamePlayProperties.Speed * GamePlayProperties.UdpInterval;
                    direction = (vector2 - (Vector2) transform.position) /
                                (GamePlayProperties.Speed * GamePlayProperties.UdpInterval);
                }
                spriteRenderer.flipX = direction.x > 0;

                var position = rigidbody2d.position;

                position.x += direction.x * GamePlayProperties.Speed * Time.deltaTime;
                position.y += direction.y * GamePlayProperties.Speed * Time.deltaTime;

                rigidbody2d.MovePosition(position);
                location = rigidbody2d.position;
            }
        }
    }
}