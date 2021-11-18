using Bogus;
using Moq.AutoMock;

namespace va.technical.challenge.tests.Fixture
{
    public abstract class FakerUtils
    {
        public AutoMocker Mocker;

        protected Faker<T> CreateFakerObject<T>() where T : class => new Faker<T>("pt_BR");

        protected T GetInstance<T>() where T : class
        {
            Mocker = new AutoMocker();
            return Mocker.CreateInstance<T>();
        }
    }
}
