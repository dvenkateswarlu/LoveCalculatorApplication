namespace LoveCalculatorApp.Services
{
    public interface ILoveCalculatorService
    {
        string CalculateLove(string username, string crushname);
        string WhatsBetweenUs(char calculateResult);
    }
}