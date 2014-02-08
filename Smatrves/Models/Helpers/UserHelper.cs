using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Smatrves.Models.Helpers
{
    public static class UserHelper
    {
        // Добавляет метод по извлечению информации об авторизованном пользователе
        public static User GetUser(this HttpSessionStateBase session)
        {
            if (session["User"] != null)
            {
                if (session["User"] is Admin)
                {
                    return (session["User"] as Admin);
                }
                if (session["User"] is Client)
                {
                    return (session["User"] as Client);
                }
                return (session["User"] as User);
            }
            else
                return null;
        }
        // Дается ли доступ для страницы
        public static bool IsOpen(this HttpSessionStateBase session, string role = null)
        {
            switch (role)
            {
                case "Admin":
                    if (session["User"] is Admin)
                        return true;
                    break;
                case "Client":
                    if (session["User"] is Client || session["User"] is Admin)
                        return true;
                    break;
            }
            return false;
        }

        // Добавляет метод по заданию информации об авторизованном пользователе
        public static void SetUser(this HttpSessionStateBase session, User user)
        {
            session["User"] = user;
        }

        // Добавляет метод по определению IP-адреса пользователя
        public static string GetUserIp(this HttpRequestBase request)
        {
            string ipList = request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }
            return request.ServerVariables["REMOTE_ADDR"];
        }
    }
}