namespace MFApp.Application.Services.Commands
{
    public interface ICommand
    {
        void Execute(string[] args);
    }
}