namespace BlackjackLib
{
    public interface IBlackjack
    {
        void Deal();
        void Hit(int playerId);
        PlayResult EvaluateHand(int playerId);
    }
}