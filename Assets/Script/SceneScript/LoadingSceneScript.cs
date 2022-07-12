using Script.Character;
using Script.Messages.CsMessages;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script
{
    public class LoadingSceneScript : MonoBehaviour
    {
        private Session serverSession;
        private void Awake()
        {
            var avatarManager = AvatarSetManager.Instance;
            GameObject appProperties = new GameObject("AppProperties");
            appProperties.AddComponent<AppProperties>();
            serverSession = new Session(AppProperties.ServerIp, AppProperties.ServerTcpPort);
            // UdpConnect udpConnect = new UdpConnect(AppProperties.ServerIp, AppProperties.ServerUdpPort);
            // udpConnect.Send(new CsChat("ahihi"));
        }

        private void Update()
        {
            if (serverSession.IsReady())
            {
                AppProperties.ServerSession = serverSession;
                SingletonDontDestroy.Instance.DoAction(() => SceneManager.LoadScene("LoginScene"));
            }
        }
    }
}