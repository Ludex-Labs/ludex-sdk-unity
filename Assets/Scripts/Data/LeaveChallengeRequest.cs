public class LeaveChallengeRequest
{
    public int ChallengeId { get; set; }
    public string PlayerPubkey { get; set; }
    public bool? Gasless { get; set; } 
}