using lawliet.Domain;
using lawliet.Repository;
using System;
using System.Collections.Generic;

namespace lawliet.Models
{
    public class Notification
    {
        public bool Save(NotificationDTO notification)
        {
            try
            {
                var notificationRep = new NotificationRepository();

                if (notification.Id != 0)
                {
                    notificationRep.Update(notification);
                    return true;
                }

                notificationRep.Create(notification);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var notificationRep = new NotificationRepository();
                notificationRep.Delete(id);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public List<NotificationDTO> FindAll()
        {
            try
            {
                var notificationRep = new NotificationRepository();
                return notificationRep.FindAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }

        public NotificationDTO Find(int id)
        {
            try
            {
                var notificationRep = new NotificationRepository();
                return notificationRep.Find(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
        }
    }
}