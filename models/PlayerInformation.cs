using System.Diagnostics.CodeAnalysis;

public class PlayerInformation
{
    public int id {get;set;}
    public string? userName {get;set;}
    public DateTime birthDate {get; set;}
    public DateTime registrationDate {get;set;}
    public string? email {get;set;}
    /*
    ///for linear progression
    */
    public int expCount {get;set;}
    public List<Flag>? flagAttribute {get;set;}
    public List<WarriorUnit>? warriorUnitAttribute {get;set;}
    public List<SniperUnit>? SniperUnitAttribute {get;set;}
    public List<EngineerUnit>? engUnitAttribute {get;set;}
    public List<BuilderUnit>? bldUnitAttribute {get;set;}
}

class FlagInit
{
    Flag _flag = new Flag();
}