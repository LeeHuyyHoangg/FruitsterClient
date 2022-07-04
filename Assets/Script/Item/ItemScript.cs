using UnityEngine;

namespace Script.Item
{
    public class ItemScript : MonoBehaviour
    {
        public ItemFunction itemFunction;
        public bool destroyOnCollide = true;

        void OnTriggerEnter2D(Collider2D other)
        {
            itemFunction.OnCollide(other.gameObject);
        }
        
    }
}