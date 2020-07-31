
using UnityEngine;
using NotificationSamples;
using System;
using Unity.Notifications.Android;
//using Unity.Notifications.iOS;


public class MyNotificationScript : MonoBehaviour
{
    [SerializeField]
    private GameNotificationsManager notificationsManager;

    private void StartNotification()
    {
        GameNotificationChannel channel = new GameNotificationChannel("Cube1",
            "This is a game notification", "We runnin, bois");
        notificationsManager.Initialize(channel);

    }

    // Start is called before the first frame update
    void Start()
    {
        StartNotification();
    }

    public void ShowNotificationAfterDelay(int sec)
    {
        ShowNotificationAfterDelay("Runner", "TADA!!!", DateTime.Now.AddSeconds(sec));
    }

    private void ShowNotificationAfterDelay(string title, string body, DateTime time)
    {
        IGameNotification createNotification = notificationsManager.CreateNotification();
        if (createNotification != null)
        {
            createNotification.Title = title;
            createNotification.Body = body;
            createNotification.DeliveryTime = time;

            var notificationToDisplay = notificationsManager.
                                        ScheduleNotification(createNotification);
            //if you want to schedule notification
            //notificationToDisplay.Reschedule = true;
        }
    }
}
