using System.Collections.Generic;

public class ResolveChallengeResponse
{
    public int ChallengeId { get; set; }
    public List<Payout> Payout { get; set; } 
    public string ResolvingAt { get; set; }
}