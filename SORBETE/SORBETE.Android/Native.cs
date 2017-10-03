using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Graphics;
using SORBETE.Droid;

[assembly: Xamarin.Forms.Dependency(typeof(Native))]
namespace SORBETE.Droid
{
   public class Native : INatives
    {
        public Native() { }
        public void notify(string title, string contentTitle)
        {
            Random rdm = new Random();
            int answer = rdm.Next(20 - 1 + 1) + 1;
            Intent intent = new Intent(MainActivity.ctx, typeof(MainActivity));
            PendingIntent pendingIntent = PendingIntent.GetActivity(MainActivity.ctx, answer, intent,
                                                                    PendingIntentFlags.UpdateCurrent);

            Notification noti = new Notification.Builder(MainActivity.ctx)
                        .SetContentTitle(title)
                        .SetContentText(contentTitle).SetAutoCancel(true)
                        .SetPriority((int)NotificationPriority.High)
                        .SetVibrate(new long[] { 100, 500 })
                        .SetDefaults(NotificationDefaults.Sound)
                        .SetDefaults(NotificationDefaults.Lights)
                        .SetSmallIcon(Resource.Drawable.Icon)
                        .SetLargeIcon(BitmapFactory.DecodeResource(MainActivity.ctx.ApplicationContext.Resources, Resource.Drawable.Icon))
                        .SetStyle(new Notification.BigTextStyle().BigText(contentTitle))
                        .SetContentIntent(pendingIntent)                        
                        .Build();
            NotificationManager notM = (NotificationManager)MainActivity.ctx.GetSystemService(Context.NotificationService);
            notM.Notify(answer, noti);
        }
    }
}