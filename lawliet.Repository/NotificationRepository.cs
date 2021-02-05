using lawliet.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace lawliet.Repository
{
    public class NotificationRepository
    {
        protected string connection = ConfigurationManager.ConnectionStrings["dbDev"].ConnectionString;
        protected IDbConnection db;

        public NotificationRepository()
        {
            this.db = new SqlConnection(this.connection);
        }

        public void Create(NotificationDTO notification)
        {
            try
            {
                this.OpenConnection();

                var dbCmd = this.db.CreateCommand();
                dbCmd.CommandText = "INSERT INTO Notifications (Message) VALUES (@message)";

                IDbDataParameter param = new SqlParameter("message", notification.Message);
                dbCmd.Parameters.Add(param);

                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Delete(int id)
        {
            try
            {
                this.OpenConnection();

                var dbCmd = this.db.CreateCommand();
                dbCmd.CommandText = "DELETE from Notifications WHERE Id=@id";

                IDbDataParameter param = new SqlParameter("id", id);
                dbCmd.Parameters.Add(param);

                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public void Update(NotificationDTO notification)
        {
            try
            {
                this.OpenConnection();

                var dbCmd = this.db.CreateCommand();
                dbCmd.CommandText = "UPDATE Notifications SET Message=@message WHERE Id=@id";

                IDbDataParameter paramMessage = new SqlParameter("message", notification.Message);
                dbCmd.Parameters.Add(paramMessage);

                IDbDataParameter paramId = new SqlParameter("id", notification.Id);
                dbCmd.Parameters.Add(paramId);

                dbCmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                this.CloseConnection();
            }
        }

        public List<NotificationDTO> FindAll()
        {
            try
            {
                this.OpenConnection();

                var dbCmd = this.db.CreateCommand();
                dbCmd.CommandText = "SELECT * FROM Notifications";
                IDataReader result = dbCmd.ExecuteReader();

                List<NotificationDTO> notifications = new List<NotificationDTO>();

                while (result.Read())
                {
                    var notification = new NotificationDTO
                    {
                        Id = (int)result["Id"],
                        Message = result["Message"].ToString(),
                    };

                    notifications.Add(notification);
                }

                return notifications;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                this.CloseConnection();
            }
        }
 
        public NotificationDTO Find(int id)
        {
            try
            {
                this.OpenConnection();

                var dbCmd = this.db.CreateCommand();
                dbCmd.CommandText = $"SELECT * FROM Notifications WHERE Id = {id}";
                IDataReader result = dbCmd.ExecuteReader();

                var notification = new NotificationDTO();

                while (result.Read())
                {
                    notification.Id = (int)result["Id"];
                    notification.Message = result["Message"].ToString();
                }

                return notification;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            finally
            {
                this.CloseConnection();
            }
        }

        protected void OpenConnection()
        {
            this.db.Open();
        }

        protected void CloseConnection()
        {
            this.db.Close();
        }
    }
}