using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

public class APIClient : MonoBehaviour
{
    public static APIClient Instance;
    public string baseUrl;
    public string sdkVersion;
    public string apiKey;
    private Dictionary<string, string> defaultHeaders;

    private void Start()
    {
        Instance = this;
        defaultHeaders = new Dictionary<string, string>
        {
            { "Authorization", $"Bearer {apiKey}" },
            { "User-Agent", GetUserAgent() }
        };
    }

    private string GetUserAgent()
    {
        string userAgent = $"ludex-sdk-unity/{sdkVersion}";
        userAgent += $" (Unity {Application.unityVersion}; {SystemInfo.operatingSystem})";
        return userAgent;
    }

    public IEnumerator IssueGetRequest<T>(string path, System.Action<T> onSuccess, System.Action<string> onError)
    {
        UnityWebRequest request = UnityWebRequest.Get(baseUrl + path);
        SetHeaders(request);
        yield return request.SendWebRequest();

        HandleResponse(request, onSuccess, onError);
    }

    public IEnumerator IssuePostRequest<T>(string path, string jsonData, System.Action<T> onSuccess, System.Action<string> onError)
    {
        UnityWebRequest request = UnityWebRequest.Post(baseUrl + path, jsonData);
        SetHeaders(request);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        HandleResponse(request, onSuccess, onError);
    }

    public IEnumerator IssuePatchRequest<T>(string path, string jsonData, System.Action<T> onSuccess, System.Action<string> onError)
    {
        UnityWebRequest request = new UnityWebRequest(baseUrl + path, "PATCH");
        SetHeaders(request);
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData));
        request.downloadHandler = new DownloadHandlerBuffer();
        yield return request.SendWebRequest();

        HandleResponse(request, onSuccess, onError);
    }

    private void SetHeaders(UnityWebRequest request)
    {
        foreach (var header in defaultHeaders)
        {
            request.SetRequestHeader(header.Key, header.Value);
        }
    }

    private void HandleResponse<T>(UnityWebRequest request, System.Action<T> onSuccess, System.Action<string> onError)
    {
        if (request.isNetworkError || request.isHttpError)
        {
            onError?.Invoke(request.error);
        }
        else
        {
            // Assuming you're dealing with JSON responses.
            T responseObject = JsonUtility.FromJson<T>(request.downloadHandler.text);
            onSuccess?.Invoke(responseObject);
        }
    }
}
