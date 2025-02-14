using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirebaseSetup : MonoBehaviour
{
    private Firebase.FirebaseApp app;

    private void Start()
    {
        Firebase.FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task => {
            var dependencyStatus = task.Result;
            if (dependencyStatus == Firebase.DependencyStatus.Available)
            {
                // Create and hold a reference to your FirebaseApp,
                // where app is a Firebase.FirebaseApp property of your application class.
                app = Firebase.FirebaseApp.DefaultInstance;

                // Set a flag here to indicate whether Firebase is ready to use by your app.
            }
            else
            {
                UnityEngine.Debug.LogError(System.String.Format(
                  "Could not resolve all Firebase dependencies: {0}", dependencyStatus));
                // Firebase Unity SDK is not safe to use here.
            }
        });

        Firebase.Messaging.FirebaseMessaging.TokenReceived += TokenReceived;
        Firebase.Messaging.FirebaseMessaging.MessageReceived += MessageReceived;

        Subscribe();
    }

    private void MessageReceived(object sender, Firebase.Messaging.MessageReceivedEventArgs e)
    {
        Debug.Log("notification" + e.Message);
    }

    private void TokenReceived(object sender, Firebase.Messaging.TokenReceivedEventArgs e)
    {
        Debug.Log("Token Received" + e.Token);
    }

    private void Subscribe()
    {
        Firebase.Messaging.FirebaseMessaging.SubscribeAsync("/topics/FusionPrix");
    }
}
