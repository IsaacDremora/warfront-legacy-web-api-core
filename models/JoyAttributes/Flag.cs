using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.SignalR;

public class Flag
{
    public int id {get;set;}
    public string? flagName {get;set;}
    public string? imgURL {get;set;}
    public bool isFree {get;set;}
    public float price {get;set;}
}