using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class WarriorUnit
{
    public int id {get;set;}
    public string? warrioirUnitSkinName {get;set;}
    public string? warriorUnitSkinURL {get;set;}
    public bool isFree {get;set;}
    public float price {get;set;}
}