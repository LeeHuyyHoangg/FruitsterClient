namespace Script.Messages.CsMessages
{
    public class CsGetRoomList : CsMessage
    {
        public int number;

        public CsGetRoomList(int number)
        {
            this.number = number;
        }
    }
}