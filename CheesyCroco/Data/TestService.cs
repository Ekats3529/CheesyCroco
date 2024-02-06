namespace CheesyCroco.Data
{
    public class TestService
    {

        public Task<Test[]> GetTestAsync()
        {
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new Test
            {
                Name = "Aaa",
                Rate = 5,
                PassCounter = 100000000
            }).ToArray());
        }
    }
}
