using System;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Identity;
using Volo.Abp.Account;
using Acme.BookStore.Books;
using Volo.Abp.Application.Dtos;
using System.Linq;

namespace Acme.BookStore.HttpApi.Client.ConsoleTestApp;

public class ClientDemoService : ITransientDependency
{
    private readonly IProfileAppService _profileAppService;
    private readonly IIdentityUserAppService _identityUserAppService;
    private readonly IBookAppService _bookAppService;

    public ClientDemoService(
        IProfileAppService profileAppService,
        IIdentityUserAppService identityUserAppService, IBookAppService bookAppService)
    {
        _profileAppService = profileAppService;
        _identityUserAppService = identityUserAppService;
        _bookAppService = bookAppService;
    }

    public async Task RunAsync()
    {
        var profileDto = await _profileAppService.GetAsync();
        Console.WriteLine($"UserName : {profileDto.UserName}");
        Console.WriteLine($"Email    : {profileDto.Email}");
        Console.WriteLine($"Name     : {profileDto.Name}");
        Console.WriteLine($"Surname  : {profileDto.Surname}");
        Console.WriteLine();

        var resultDto = await _identityUserAppService.GetListAsync(new GetIdentityUsersInput());
        Console.WriteLine($"Total users: {resultDto.TotalCount}");
        foreach (var identityUserDto in resultDto.Items)
        {
            Console.WriteLine($"- [{identityUserDto.Id}] {identityUserDto.Name}");
        }
        var listOfBooks = await _bookAppService.GetListAsync();
        Console.WriteLine($"Books: {string.Join(", ", listOfBooks.Items.Select(p => p.Name).ToList())}");
    }
}
