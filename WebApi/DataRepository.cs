namespace WebApi
{
    public interface IDataRepository
    {
        IReadOnlyCollection<Guid> GetData(int count);
    }

    public class DataRepository : IDataRepository
    {
        public IReadOnlyCollection<Guid> GetData(int count)
        {
            var data = new List<Guid>();
            for(int i = 0; i < count; i++)
            {
                data.Add(Guid.NewGuid());
            }
            return data;
        }
    }
}
