using MFApp.Application.Services;

namespace MFApp.Application.Services.Commands
{
    public class CurrentPortfolioCommand : ICommand
    {
        private readonly PortfolioManager _portfolioManager;

        public CurrentPortfolioCommand(PortfolioManager portfolioManager)
        {
            _portfolioManager = portfolioManager;
        }

        public void Execute(string[] args)
        {
            _portfolioManager.SetCurrentPortfolio(args);
        }
    }
}