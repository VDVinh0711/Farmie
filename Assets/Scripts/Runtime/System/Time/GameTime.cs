using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


[System.Serializable]
public class GameTime
{
    public int year;

    /*public enum Season
    {
        spring,
        summer,
        fall,
        winter
    }*/

    public enum DayOfWeek
    {
        monday,
        tuesday,
        wednesday,
        thursday,
        friday,
        saturday,
        sunday
    }

    public int month;
    public int day;
    public int hour;
    public int minute;
    public int second;


   


    public GameTime(int year, int month, int day, int hour, int minute, int second)
    {
        this.year = year;
        this.month = month;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

   

    public GameTime(){}

public GameTime(GameTime gametime)
    {
        this.year = gametime.year;
        this.month = gametime.month;
        this.day = gametime.day;
        this.hour = gametime.hour;
        this.minute = gametime.minute;
        this.second = gametime.second;
    }
    public void UpdateTime()
    {
        second++;
        if(second >= 60)
        {
            second = 0;
            minute++;
        }
        if(minute >=60)
        {
            minute = 0;
            hour++;   
        }
        if(hour >=24)
        {
            hour = 0;
            day++;
        }
        if(day >30)
        {
            day = 1;
            month++;
            if (month > 12)
            {
                month = 1;
                year++;
            }
        }
    }

    public static int HourInMinute(int hour)
    {
        return hour * 60;
    }
    public static int DaytoHour(int day)
    {
        return day * 24;
    }
   
    public static int YearToDay(int year)
    {
        return year * 4 * 30;
    }
    public DayOfWeek GetDay()
    {
        int dayPassd = YearToDay(year) + MonthToDay(month,year) + day;
        int dayIndex = dayPassd % 7;
        return (DayOfWeek)dayIndex;
    }
    public static int MinutetoSecond(int minute)
    {
        return minute * 60;
    }
    public static int DaytoSecond(int day)
    {
        return MinutetoSecond(HourInMinute(DaytoHour(day)));
    }


    public static int CompareGameTime(GameTime gameTime1 ,  GameTime gameTime2)
    {
        int gameTime1second = MinutetoSecond(HourInMinute( DaytoHour(YearToDay(gameTime1.year)) + MinutetoSecond(HourInMinute(DaytoHour(MonthToDay(gameTime1.month,gameTime1.year)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime1.day))) + MinutetoSecond(HourInMinute(gameTime1.hour)) + MinutetoSecond(gameTime1.minute) + gameTime1.second;
        int gameTine2second = MinutetoSecond(HourInMinute(DaytoHour(YearToDay(gameTime2.year) )+ MinutetoSecond(HourInMinute(DaytoHour(MonthToDay(gameTime2.month,gameTime2.year)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime2.day))) + MinutetoSecond(HourInMinute(gameTime2.hour)) + MinutetoSecond(gameTime2.minute) + gameTime2.second;
        int differenthour = Mathf.Abs(gameTine2second - gameTime1second);
        return differenthour;
    }
    public static string ShowTime(GameTime GameTimeShow)
    {
        return GameTimeShow.year + " - " + GameTimeShow.month + " - " + GameTimeShow.day + " - " + GameTimeShow.hour + " - " + GameTimeShow.minute + " - "  + GameTimeShow.second;
    }

    public static float TimetoSecond(GameTime gameTime)
    {
        return  MinutetoSecond(HourInMinute(DaytoHour(YearToDay(gameTime.year) )+ MinutetoSecond(HourInMinute(DaytoHour(MonthToDay(gameTime.month,gameTime.year)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime.day))) + MinutetoSecond(HourInMinute(gameTime.hour)) + MinutetoSecond(gameTime.minute) + gameTime.second;
    }

    public static int GamrTimetoSecond(GameTime gameTime)
    {
        return   MinutetoSecond(HourInMinute( DaytoHour(YearToDay(gameTime.year)) + MinutetoSecond(HourInMinute(DaytoHour(MonthToDay(gameTime.month,gameTime.year)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime.day))) + MinutetoSecond(HourInMinute(gameTime.hour)) + MinutetoSecond(gameTime.minute) + gameTime.second;
    }

    public static GameTime GetRealTIme()
    {
        DateTime now = DateTime.Now;
        int year = now.Year;
        int month = now.Month;
        int day = now.Day;
        int hour = now.Hour;
        int minute = now.Minute;
        int second = now.Second;
        return new GameTime(year, month, day, hour, minute, second);
    }


    private  static int MonthToDay( int month , int year)
    {
        switch (month)
        {
           case 1 :
               return 31;
               break;
           case 2 :
                   return   year % 4 == 0 && (year % 100 != 0 || year % 400 == 0) ? 29 : 28;
           break;
           case 3:
               return 31;
           break;
           case 4:
               return 30;
               break;
           case 5:
               return 31;
               break;
           case 6:
               return 30;
               break;
           case 7:
               return 31;
               break;
           case 8:
               return 31;
               break;
           case 9:
               return 30;
               break;
           case 10:
               return 31;
               break;
           case 11:
               return 30;
               break;
           case 12:
               return 31;
               break;
              
        }

        return 30;
    }
        

}
