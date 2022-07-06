using System.Net;
using UnityEngine.SceneManagement;

namespace Script.Messages.ScMessages
{
    public class ScCreateRoom: ScMessage
    {
        public HttpStatusCode statusCode;
        public string roomID;
        
        public override void OnMessage(Session session)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                UserProperties.UserRoom.RoomID = roomID;
                SceneManager.LoadScene("RoomScene");
            }
        }
    }
}