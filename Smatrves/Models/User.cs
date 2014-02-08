using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Smatrves.Models
{
    public class User
    {
        [Key]
        public int IdUser { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
    }
    public class Admin:User
    {
        [Required]
        public string Name { get; set; }
    }
    public enum StatusClient : int
    {
        Open = 0,//не подтвержден по мылу
        Works = 1,//работает
        Banned = 2,//забанен
    }
    public enum TypeAccount : int
    {
        //Новичок, Мастер, Профи, Задрот
        Newcomer = 0, 
        Master =1,
        Pros =2,
        Zadrot=3
    }
    public enum UpgradeType : int
    { 
        //Basic / Gold / Ultimate
        Basic = 0,
        Gold =1,
        Ultimate = 2
    }
    public class Client : User 
    {
        //Ava Аватарка
        public string Ava{get;set;}
        //Regdate Дата реистрации
        [Required]
        public DateTime Regdate{get;set;}
        //DateLastEnter Дата последнего входа
        [Required]
        public DateTime DateLastEnter { get; set; }
        //Status Статус аккаунта: забанен, открыт, и т.д. [скрытая строка. если забанен, то появляется оповещение об этом]
        [Required]
        public StatusClient Status { get; set; }
        //DateofBirthDay Дата дня рождения, будем плюшки давать [скрыто / по желанию]
        public DateTime DateofBirthDay { get; set; }
        //WMID Вмид [скрыто]
        public string WMID { get; set; }
        //WMR Кошелек wmr [скрыто]
        public string WMR { get; set; }
        //Paypalemail Почта для выплат на paypal
        public string Paypalemail { get; set; } 
        //Referer Id пригласившего участника [скрыто]
        public Client Referer { get; set; }
        //Refstotal Количество рефералов [будет 1 уровень, ибо нех]
        //Serftotal Сколько просмотрено всего сайтов в сёрфинге(ручном автоматическом)(показывать при продаже реферала тоже)
        //Taskstotal Сколько выполнено заданий (при продаже показывать сколько в день выполняется заданий) [сколько этому пользователю оплачено / отклонено]
        //Dailyearnings Сколько заработано за день [в валюте / в кредитах], всего
        //Refearnings Сколько заработано на рефералах [в валюте / в кредитах] за день, всего
        //Accbalance Баланс аккаунта
        [Required]
        public decimal Accbalance { get; set; }
        //Crbalance Баланс аккаунта в кредитах
        [Required]
        public int Crbalance { get; set; }
        //Userip ip адрес пользователя, используется ли прокси
        [Required]
        public string Userip { get; set; }
        //Targetingdata Сортировка по ip ,какая страна, город (для таргетинга)
        [Required]
        public string Targetingdata { get; set; }
        //Rating Рейтинг
        [Required]
        public int Rating { get; set; }
        //Utctime Часовой пояс
        //Acctype Тип аккаунта [Новичок, Мастер, Профи, Задрот, еще какой-нибудь]
        [Required]
        public TypeAccount Acctype { get; set; }
        [Required]
        //Accupgrade Платный апгрейд аккаунта [Basic / Gold / Ultimate / Еще какой-нибудь]*/
        public UpgradeType Accupgrade { get; set; }

        public virtual ICollection<Site> Sites { get; set; }
    }
}