using B3.DesafioCalculo.Business.Contracts;
using B3.DesafioCalculo.Business;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;

namespace B3.DesafioCalculo.UnitTests.ServicesRegistration
{
    [TestFixture]
    public class BusinessServiceRegistrationTests
    {
        private Mock<IConfiguration> _mockConfiguration;
        private Mock<IConfigurationSection> _mockConfigurationSection;
        private IServiceCollection _services;

        [SetUp]
        public void Setup()
        {
            _mockConfiguration = new Mock<IConfiguration>();
            _mockConfigurationSection = new Mock<IConfigurationSection>();
            _mockConfiguration.Setup(x => x.GetSection(It.IsAny<string>())).Returns(_mockConfigurationSection.Object);

            _services = new ServiceCollection();
        }

        [Test]
        public void AddBusinessServices_RegistersServicesCorrectly()
        {
            // Act
            var result = BusinessServiceRegistration.AddBusinessServices(_services, _mockConfiguration.Object);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(result, Is.InstanceOf<IServiceCollection>());
                Assert.That(_services.Any(sd => sd.ServiceType == typeof(ICalculadoraInvestimentosBusiness)), Is.True);
            });
        }
    }
}
