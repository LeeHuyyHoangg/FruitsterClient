using Script.Messages.CsMessages.GamePlay;
using UnityEngine;

namespace Script.Item
{
    public class Fruit : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D other)
        {
            AppProperties.ServerSession.SendMessage(new CsUserObtainFruit());
        }
    }
}