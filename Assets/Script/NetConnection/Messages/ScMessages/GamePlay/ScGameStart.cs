using System;
using System.Collections.Generic;
using Script.Messages.ScMessages;
using Script.Model;
using UnityEngine.SceneManagement;

namespace Script.Messages.CsMessages.GamePlay
{
    [Serializable]
    public class ScGameStart : ScMessage
    {
        public List<PlayerInitState> playerInitStateList;
        public override void OnMessage(Session session)
        {
            SingletonDontDestroy.Instance.DoAction(() =>
            {
                SceneManager.LoadScene("PlayScene");
                PlaySceneScript.Instance.InitPlayer(playerInitStateList);
            });
        }
    }
}