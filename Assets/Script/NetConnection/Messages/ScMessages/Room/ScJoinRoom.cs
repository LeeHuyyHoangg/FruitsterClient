using System.Net;
using UnityEngine.SceneManagement;

namespace Script.Messages.ScMessages
{
    public class ScJoinRoom : ScMessage
    {
        public HttpStatusCode statusCode;
        public override void OnMessage(Session session)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                SceneManager.LoadScene("RoomScene");
            }
        }
    }
}