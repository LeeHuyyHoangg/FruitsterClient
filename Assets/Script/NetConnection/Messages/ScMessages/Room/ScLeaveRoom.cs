using System.Net;
using UnityEngine.SceneManagement;

namespace Script.Messages.ScMessages
{
    public class ScLeaveRoom : ScMessage
    {
        public HttpStatusCode statusCode;
        public override void OnMessage(Session session)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                UserProperties.UserRoom = null;
                SceneManager.LoadScene("RoomAvatarSelectScene");
            }
        }
    }
}