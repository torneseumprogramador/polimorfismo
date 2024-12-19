using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using CadastroCliente.Services;

namespace dotnet.Controllers;

public class ClientesController : Controller
{
    private readonly ILogger<ClientesController> _logger;
    private readonly PessoaService _pessoaService;

    public ClientesController(ILogger<ClientesController> logger, PessoaService pessoaService)
    {
        _logger = logger;
        _pessoaService = pessoaService;
    }

     public async Task<IActionResult> Index()
    {
        try
        {
            var clientes = await _pessoaService.GetAllAsync(); // Obtém todos os clientes
            return View(clientes);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao buscar os clientes.");
            return View("Error"); // Renderiza uma view de erro, caso ocorra uma exceção
        }
    }
}
