using Script.Messages.CsMessages;
using UnityEngine;

namespace Script
{
    public class RoomSceneScript : MonoBehaviour
    {
        private void Start()
        {
            AppProperties.ServerSession.SendMessage(new CsGetRoom(UserProperties.UserRoom.RoomID));
        }

        public void LeaveRoom()
        {
            AppProperties.ServerSession.SendMessage(new CsLeaveRoom());
        }
    }
}