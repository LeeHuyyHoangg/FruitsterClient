using Script.Messages.CsMessages.GamePlay;
using UnityEngine;

namespace Script.Item
{
    public class Fruit : ItemFunction
    {

        public override void OnCollide(GameObject gameObject)
        {
            // AppProperties.ServerSession.SendMessage(new CsUserObtainFruit());
        }
    }
}