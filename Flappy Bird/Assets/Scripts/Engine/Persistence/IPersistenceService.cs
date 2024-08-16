namespace JGM.Engine
{
    public interface IPersistenceService
    {
        int LoadInt(string key);
        void SaveInt(string key, int value);
    }
}