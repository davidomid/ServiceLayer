using System;
using System.Threading.Tasks;

namespace ExampleServices
{
    public interface IUserService
    {
        Task AddUserAsync(User user);
    }
    public interface ICommunicationService
    {
        Task SendWelcomeEmailAsync(User user); 
    }

    public interface ILogger
    {
        void LogException(Exception exception);
    }

    public class RegistrationService
    {
        private readonly IUserService _userService;
        private readonly ICommunicationService _communicationService;
        private readonly ILogger _logger;

        public RegistrationService(IUserService userService, ICommunicationService communicationService, ILogger logger)
        {
            _userService = userService;
            _communicationService = communicationService;
            _logger = logger;
        }

        public async Task RegisterUserAsync(User user)
        {
            await _userService.AddUserAsync(user);
            await _communicationService.SendWelcomeEmailAsync(user);
        }
    }

    public class User
    {
    }
    public class UsernameAlreadyExistsException : Exception { }

    public class InvalidUserDetailsException : Exception
    {
    }

}
