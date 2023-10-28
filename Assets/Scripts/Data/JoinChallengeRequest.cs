using System.Collections.Generic;

public class JoinChallengeRequest
{
    public int ChallengeId { get; set; }
    public string PlayerPubkey { get; set; }
    public bool? Gasless { get; set; }
    public List<Offering> Offerings { get; set; }
}
public class Offering
{
    public string Mint { get; set; }
    public int Amount { get; set; }
}