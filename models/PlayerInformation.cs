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
    public IEnumerable<Flag>? flagAttribute {get;set;}
    public IEnumerable<WarriorUnit>? warriorUnitAttribute {get;set;}
}