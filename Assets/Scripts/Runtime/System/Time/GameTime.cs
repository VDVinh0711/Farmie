using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]
public class GameTime
{
    public int year;

    public enum Season
    {
        spring,
        summer,
        fall,
        winter
    }

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

    public Season season;
    public int day;
    public int hour;
    public int minute;
    public int second;


    public GameTime(int year, Season season, int day, int hour, int minute, int second)
    {
        this.year = year;
        this.season = season;
        this.day = day;
        this.hour = hour;
        this.minute = minute;
        this.second = second;
    }

    public GameTime(){}

public GameTime(GameTime gametime)
    {
        this.year = gametime.year;
        this.season = gametime.season;
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
            if(season == Season.winter)
            {
                season = Season.spring;
                year++;
            }
            else
            {
            season++;
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
    public static int SeasonstoDay(Season season)
    {
        int seasonIndex = (int)season;
        return seasonIndex * 30;    
    }
    public static int YearToDay(int year)
    {
        return year * 4 * 30;
    }
    public DayOfWeek GetDay()
    {
        int dayPassd = YearToDay(year) + SeasonstoDay(season) + day;
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
        int gameTime1second = MinutetoSecond(HourInMinute( DaytoHour(YearToDay(gameTime1.year)) + MinutetoSecond(HourInMinute(DaytoHour(SeasonstoDay(gameTime1.season)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime1.day))) + MinutetoSecond(HourInMinute(gameTime1.hour)) + MinutetoSecond(gameTime1.minute) + gameTime1.second;
        int gameTine2second = MinutetoSecond(HourInMinute(DaytoHour(YearToDay(gameTime2.year) )+ MinutetoSecond(HourInMinute(DaytoHour(SeasonstoDay(gameTime2.season)))))) + MinutetoSecond(HourInMinute(DaytoHour(gameTime2.day))) + MinutetoSecond(HourInMinute(gameTime2.hour)) + MinutetoSecond(gameTime2.minute) + gameTime2.second;
        int differenthour = Mathf.Abs(gameTine2second - gameTime1second);
        return differenthour;
    }
    public static string ShowTime(GameTime GameTimeShow)
    {
        return GameTimeShow.year + " - " + GameTimeShow.season + " - " + GameTimeShow.day + " - " + GameTimeShow.hour + " - " + GameTimeShow.minute + " - "  + GameTimeShow.second;
    }

}
