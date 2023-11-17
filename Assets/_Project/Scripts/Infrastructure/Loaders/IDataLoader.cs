namespace Infrastructure.Resources
{
    public interface IDataLoader
    {
        bool TryLoad<T>(out T output);
    }
}