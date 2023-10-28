using System.Collections.Generic;

public class ChallengeResponse
{
    public int ChallengeId { get; set; }
    public Payout PayoutInfo { get; set; }
    public string State { get; set; }
    public string BlockchainAddress { get; set; }
    public List<object> Players { get; set; } 
}
public class Payout
{
    public int Id { get; set; }
    public string EntryFee { get; set; }
    public string MediatorRake { get; set; }
    public string ProviderRake { get; set; }
    public string Chain { get; set; }
}