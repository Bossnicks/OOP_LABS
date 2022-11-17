namespace Laba8
{
    public interface IGeneric<T>
    {
        void Enqueue(T item);
        T Dequeue();
        void Contains(T item);
    }

}
