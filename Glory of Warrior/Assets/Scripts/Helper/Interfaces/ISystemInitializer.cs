namespace Helper.Interfaces
{
    public enum SystemType
    {
        Player,
        Enemy,
        Health
    }
    public interface ISystemInitializer
    {
        void InitializeSystem();
    }
}