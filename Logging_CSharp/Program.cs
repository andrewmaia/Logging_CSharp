using Logging_CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;


DiComHost();

void DiComHost()
{
    IHostBuilder hostBuilder = Host.CreateDefaultBuilder(args);
    //Por padrão o host já vem com mecanismos de logs configurados
    //Para retirar é necessário rodar o comando ClearProviders
    //E depois você pode adicionar somente os mecanismos que você deseja
    //No caso deixei apenas log via console
    /*.ConfigureLogging(logging =>
    {
            logging.ClearProviders();
            logging.AddConsole();
    });*/

    //Configurando Injeção de dependencia
    hostBuilder

        .ConfigureServices(services => services
            .AddScoped<IServico1, Servico1>()
        );


    IHost host = hostBuilder.Build();
    IServico1 servico1 = host.Services.GetRequiredService<IServico1>();
    servico1.Log();
    host.Run();
}





