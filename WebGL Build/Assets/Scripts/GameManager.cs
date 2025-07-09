
using System;
using SpacetimeDB;
using SpacetimeDB.Types;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    const string SERVER_URL = "http://127.0.0.1:3000";
    const string SERVER_NAME = "space-reproduce";

    public static DbConnection Conn { get; private set; }
    public static Action<string> OnDbConnected;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    public void OnLoginSuccess(string token)
    {
        Debug.Log($"Firebase token:  {token}");
        Initialize(token);
    }

    void Initialize(string token)
    {
        Conn = DbConnection
            .Builder()
            .OnConnect(HandleConnected)
            .OnConnectError(HandleConnectError)
            .WithUri(SERVER_URL)
            .WithModuleName(SERVER_NAME)
            .WithToken(token)
            .Build();
    }

    void HandleConnected(DbConnection conn, Identity identity, string authToken)
    {
        Debug.Log($"identity: {identity}");
        Debug.Log($"authToken: {authToken}");
        OnDbConnected.Invoke(identity.ToString());
        Conn.SubscriptionBuilder()
        .OnApplied(HandleAppliedSubscription)
        .SubscribeToAllTables();
    }

    void HandleConnectError(Exception ex)
    {
        Debug.LogError($"Connection error: {ex}");
    }

    void HandleAppliedSubscription(SubscriptionEventContext ctx)
    {
        Debug.Log("Subscription applied");
    }
}

namespace System.Runtime.CompilerServices
{
    internal static class IsExternalInit { }
}