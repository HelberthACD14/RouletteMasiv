public class RouletteBet
{
    public long Id { get; set; }
    public long RelatedId { get; set; }
    public bool BetTypeColor { get; set; }
    public int BetArgument { get; set;}
    public float BetMoney { get; set;}
    public long userId { get; set; }
}