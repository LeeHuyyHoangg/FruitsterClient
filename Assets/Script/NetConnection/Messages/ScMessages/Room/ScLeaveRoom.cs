using System;
using System.Net;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.Messages.ScMessages
{
    public class ScLeaveRoom : ScMessage
    {
        public string userID;
        public HttpStatusCode statusCode;
        public override void OnMessage(Session session)
        {
            if (statusCode == HttpStatusCode.OK)
            {
                if (userID.Equals(UserProperties.MainPlayer.userID))
                {
                    UserProperties.UserRoom = null;
                    SingletonDontDestroy.Instance.DoAction(() => SceneManager.LoadScene("AvatarRoomSelectScene"));

                }
                else
                {
                    foreach (var user in UserProperties.UserRoom.Players.ToArray())
                    {
                        if (user.userID.Equals(userID))
                        {
                            UserProperties.UserRoom.Players.Remove(user);
                            break;
                        }
                    }
                    SingletonDontDestroy.Instance.DoAction(() => RoomSceneScript.Instance.RefreshRoom());
                }
            }
            else
            {
                Debug.Log(statusCode);
            }
        }
    }
}