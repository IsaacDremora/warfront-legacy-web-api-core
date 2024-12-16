using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;

public class User
{
    public int id {get;set;}
    /*
    ///usernameHash (login hash) and passHash (password hash) is hashsumm for OAuth 2.0. and JWT 
    */
    public string? usernameHash {get;set;}
    public string? passHash {get;set;}
    public string? userName {get;set;}
    public DateTime birthDate {get; set;}
    public DateTime registrationDate {get;set;}
    public string? email {get;set;}
    /*
    ///for linear progression
    */
    public BigInteger expCount {get;set;}
    public IEnumerable<Flag>? flagAttribute {get;set;}
    public IEnumerable<WarriorUnit>? warriorUnitAttribute {get;set;}
}