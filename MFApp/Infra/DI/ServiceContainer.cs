using MFApp.Application.Services;
using MFApp.Application.Services.Commands;
using MFApp.Infra.Data;
using MFApp.Infra.FileSystem;

namespace MFApp.Infra.DI
{
    public interface IServiceContainer
    {
        IApplicationService GetApplicationService();
        IInputValidationService GetInputValidationService();
    }

    public class ServiceContainer : IServiceContainer
    {
        private readonly IFileReader _fileReader;
        private readonly IFundRepository _fundRepository;
        private readonly PortfolioManager _portfolioManager;
        private readonly IApplicationService _applicationService;
        private readonly IInputValidationService _inputValidationService;

        public ServiceContainer()
        {
            // Initialize infrastructure services
            _fileReader = new FileReader();
            _fundRepository = new FundRepository();
            
            // Initialize application services
            _portfolioManager = new PortfolioManager(_fundRepository);
            _applicationService = new ApplicationService(_portfolioManager, _fileReader);
            _inputValidationService = new InputValidationService();
        }

        public IApplicationService GetApplicationService()
        {
            return _applicationService;
        }

        public IInputValidationService GetInputValidationService()
        {
            return _inputValidationService;
        }
    }
} 