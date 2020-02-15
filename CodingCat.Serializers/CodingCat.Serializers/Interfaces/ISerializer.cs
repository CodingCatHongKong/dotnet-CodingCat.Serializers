namespace CodingCat.Serializers.Interfaces
{
    public interface ISerializer<TInput>
    {
        byte[] ToBytes(TInput input);

        TInput FromBytes(byte[] bytes);
    }

    public interface ISerializer<T, TOutput>
    {
        TOutput Serialize(T input);

        T Deserialize(TOutput body);
    }
}