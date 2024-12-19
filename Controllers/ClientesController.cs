using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnet.Models;
using CadastroCliente.Services;
using CadastroCliente.Models;

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

    [Route("/clientes")]
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

    [HttpGet]
    [Route("/clientes/fisico/novo")]
    public IActionResult CreatePessoaFisica()
    {
        return View();
    }

    [HttpPost]
    [Route("/clientes/fisico/novo")]
    public async Task<IActionResult> CreatePessoaFisica(PessoaFisica model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _pessoaService.AddAsync(model); // Adiciona ao banco
            TempData["Success"] = "Pessoa Física cadastrada com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Erro ao cadastrar Pessoa Física: " + ex.Message);
            return View(model);
        }
    }

    [HttpGet]
    [Route("/clientes/juridica/novo")]
    public IActionResult CreatePessoaJuridica()
    {
        return View();
    }

    [HttpPost]
    [Route("/clientes/juridica/novo")]
    public async Task<IActionResult> CreatePessoaJuridica(PessoaJuridica model)
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        try
        {
            await _pessoaService.AddAsync(model); // Adiciona ao banco
            TempData["Success"] = "Pessoa juridica cadastrada com sucesso!";
            return RedirectToAction("Index");
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Erro ao cadastrar Pessoa juridica: " + ex.Message);
            return View(model);
        }
    }

    [HttpPost]
    public async Task<IActionResult> DeleteFisica(int id)
    {
        try
        {
            await _pessoaService.DeleteAsync(id, TipoPessoa.Fisica); // Chama o serviço para exclusão
            TempData["Success"] = "Cliente excluído com sucesso!"; // Mensagem de sucesso
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Erro ao excluir cliente: " + ex.Message; // Mensagem de erro
        }

        return RedirectToAction("Index"); // Redireciona para a lista de clientes
    }

    [HttpPost]
    public async Task<IActionResult> DeleteJuridica(int id)
    {
        try
        {
            await _pessoaService.DeleteAsync(id, TipoPessoa.juridica); // Chama o serviço para exclusão
            TempData["Success"] = "Cliente excluído com sucesso!"; // Mensagem de sucesso
        }
        catch (Exception ex)
        {
            TempData["Error"] = "Erro ao excluir cliente: " + ex.Message; // Mensagem de erro
        }

        return RedirectToAction("Index"); // Redireciona para a lista de clientes
    }

}
