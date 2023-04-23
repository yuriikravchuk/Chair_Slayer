public interface ISaveProvider<T>
{
    T TryGetSave();
    void UpdateSave(T save);
}
