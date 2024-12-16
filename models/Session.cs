using System.ComponentModel.DataAnnotations;

public class Session
{
    public int id {get;set;}
    public DateTime sessionDateTime {get;set;}
    public User? winner {get;set;}
    public User? loser {get;set;}
}