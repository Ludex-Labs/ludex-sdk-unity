using UnityEngine;
using System.Collections;

public class Challenge : MonoBehaviour
{
    private APIClient apiClient;
    private readonly string BASE_PATH = "/v2/challenge";

    private void Start()
    {
        apiClient = APIClient.Instance;
    }

    public void GetChallenge(int challengeId, System.Action<ChallengeResponse> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(apiClient.IssueGetRequest<ChallengeResponse>($"{BASE_PATH}/{challengeId}", onSuccess, onError));
    }

    public void GetChallenges(System.Action<ChallengeResponse[]> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(apiClient.IssueGetRequest<ChallengeResponse[]>($"{BASE_PATH}/", onSuccess, onError));
    }

    public void CreateChallenge(CreateChallengeRequest challenge, System.Action<CreateChallengeResponse> onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(challenge);
        StartCoroutine(apiClient.IssuePostRequest<CreateChallengeResponse>($"{BASE_PATH}/", jsonData, onSuccess, onError));
    }

    public void GenerateJoin(JoinChallengeRequest joinChallenge, System.Action<JoinChallengeResponse> onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(joinChallenge);
        StartCoroutine(apiClient.IssuePostRequest<JoinChallengeResponse>($"{BASE_PATH}/{joinChallenge.ChallengeId}/join", jsonData, onSuccess, onError));
    }

    public void GenerateLeave(LeaveChallengeRequest leaveChallenge, System.Action<LeaveChallengeResponse> onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(leaveChallenge);
        StartCoroutine(apiClient.IssuePostRequest<LeaveChallengeResponse>($"{BASE_PATH}/{leaveChallenge.ChallengeId}/leave", jsonData, onSuccess, onError));
    }

    public void LockChallenge(int challengeId, System.Action<LockChallengeResponse> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(apiClient.IssuePatchRequest<LockChallengeResponse>($"{BASE_PATH}/{challengeId}/lock", "{}", onSuccess, onError));
    }

    public void CancelChallenge(int challengeId, System.Action<CancelChallengeResponse> onSuccess, System.Action<string> onError)
    {
        StartCoroutine(apiClient.IssuePatchRequest<CancelChallengeResponse>($"{BASE_PATH}/{challengeId}/cancel", "{}", onSuccess, onError));
    }

    public void ResolveChallenge(ResolveChallengeRequest resolveChallenge, System.Action<ResolveChallengeResponse> onSuccess, System.Action<string> onError)
    {
        string jsonData = JsonUtility.ToJson(resolveChallenge);
        StartCoroutine(apiClient.IssuePatchRequest<ResolveChallengeResponse>($"{BASE_PATH}/{resolveChallenge.ChallengeId}/resolve", jsonData, onSuccess, onError));
    }
}
