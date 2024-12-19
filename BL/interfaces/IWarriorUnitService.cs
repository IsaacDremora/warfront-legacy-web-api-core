interface IWarriorUnitService
{
    Task AddWarUnitAtUser(int _userId, int _warUnitId);
    Task RemoveWarUnitAtUser(int _userId, int _warUnitId);
}