using System.ComponentModel.DataAnnotations;

public class Session
{
    public int id {get;set;}
    public DateTime sessionDateTime {get;set;}
    public PlayerInformation? winner {get;set;}
    public PlayerInformation? loser {get;set;}
}