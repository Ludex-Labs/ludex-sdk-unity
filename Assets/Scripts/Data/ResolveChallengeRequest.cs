using System.Collections.Generic;

public class ResolveChallengeRequest
{
    public int ChallengeId { get; set; }
    public List<Payout> Payout { get; set; }
}