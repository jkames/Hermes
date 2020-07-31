using System.Collections;
using System.Collections.Generic;
using Unity.Notifications.Android;
using UnityEngine;

public class MobileNotificationManager : MonoBehaviour
{

    public AndroidNotificationChannel defaultNotificationChannel;

    private int identifier;

    private void Start()
    {

        defaultNotificationChannel = new AndroidNotificationChannel()
        {
            Id = "default_channel",
            Name = "Default Channel",
            Description = "For Generic notifications",
            Importance = Importance.Default,
        };

        AndroidNotificationCenter.RegisterNotificationChannel(defaultNotificationChannel);


        AndroidNotification notification = new AndroidNotification()
        {
            Title = "Test Notification!",
            Text = "This is a test notification!",
            SmallIcon = "default",
            LargeIcon = "default",
            FireTime = System.DateTime.Now.AddSeconds(10),
        };

        identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");


        AndroidNotificationCenter.NotificationReceivedCallback receivedNotificationHandler = delegate (AndroidNotificationIntentData data)
        {
            var msg = "Notification received : " + data.Id + "\n";
            msg += "\n Notification received: ";
            msg += "\n .Title: " + data.Notification.Title;
            msg += "\n .Body: " + data.Notification.Text;
            msg += "\n .Channel: " + data.Channel;
            Debug.Log(msg);
        };

        AndroidNotificationCenter.OnNotificationReceived += receivedNotificationHandler;

        var notificationIntentData = AndroidNotificationCenter.GetLastNotificationIntent();

        if (notificationIntentData != null)
        {
            Debug.Log("App was opened with notification!");
        }

    }

    private void OnApplicationPause(bool pause)
    {

        if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Scheduled)
        {
            //If the player has left the game and the game is not running. Send them a new notification
            AndroidNotification newNotification = new AndroidNotification()
            {
                Title = "Reminder Notification!",
                Text = "You've paused Unity Royale!",
                SmallIcon = "default",
                LargeIcon = "default",
                FireTime = System.DateTime.Now
            };

            // Replace the currently scheduled notification with a new notification.
            AndroidNotificationCenter.UpdateScheduledNotification(identifier, newNotification, "default_channel");
        }
        else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Delivered)
        {
            //Remove the notification from the status bar
            AndroidNotificationCenter.CancelNotification(identifier);
        }
        else if (AndroidNotificationCenter.CheckScheduledNotificationStatus(identifier) == NotificationStatus.Unknown)
        {
            AndroidNotification notification = new AndroidNotification()
            {
                Title = "Test Notification!",
                Text = "This is a test notification!",
                SmallIcon = "default",
                LargeIcon = "default",
                FireTime = System.DateTime.Now.AddSeconds(10),
            };

            //Try sending it again
            identifier = AndroidNotificationCenter.SendNotification(notification, "default_channel");
        }


    }




}
