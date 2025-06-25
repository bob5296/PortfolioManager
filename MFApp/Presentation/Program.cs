using MFApp.Application.Services;
using MFApp.Infra.DI;

namespace MFApp.Presentation;

class Program
{
    static void Main(string[] args)
    {
        var serviceContainer = new ServiceContainer();
        var inputValidationService = serviceContainer.GetInputValidationService();
        var applicationService = serviceContainer.GetApplicationService();

        // Validate command line arguments
        var (isValid, errorMessage) = inputValidationService.ValidateCommandLineArgs(args);
        if (!isValid)
        {
            Console.WriteLine(errorMessage);
            return;
        }

        string inputFilePath = args[0];

        // For local debugging (uncomment as needed)
        // inputFilePath = @"C:\Users\pkumar1\source\repos\MFApp\MFApp\sample_input1.txt";

        // Process the input file
        applicationService.ProcessInputFile(inputFilePath);
    }
}
