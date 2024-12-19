interface IFlagService
{
    Task AddFlagAtUser(int _flagId, int _pinfId);
    Task RemoveFlagAtUser(int _flagId, int _pinfId);
}