namespace Script.Messages.ScMessages
{
    public abstract class ScMessage : Message
    {
        public abstract void OnMessage(Session session);
    }
}