﻿using Microsoft.AspNetCore.Mvc;
using Serilog;
using SGM.ApplicationServices.Interfaces;
using SGM.ApplicationServices.ViewModels;
using System;
using System.Security.Cryptography;
using System.Text.Json;

namespace SGM.WebApi.Controllers
{
    [ApiController]
    [Route("SGM")]
    [Produces("application/json")]
    public class ColaboradorController : ControllerBase
    {
        private readonly Serilog.ILogger _logger;
        private readonly IColaboradorServices _colaboradorServices;

        public ColaboradorController(Serilog.ILogger logger,
            IColaboradorServices colaboradorServices)
        {
            _logger = logger;
            _colaboradorServices = colaboradorServices;
        }

        [HttpGet]
        [Route("colaborador")]
        public IActionResult GetColaboradorForAll()
        {
            try
            {
                _logger.Information("[ColaboradorController.GetColaboradorForAll] - Solicitação de todos os colaboradores");
               
                var clientes = _colaboradorServices.GetByAll();
               
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ColaboradorController.GetColaboradorForAll] - Erro ao efetuar a busca de todos os colaboradores erro:{ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("colaborador/{colaboradorId}")]
        public IActionResult GetColaboradorById(int colaboradorId)
        {
            try
            {
                _logger.Information($"[ColaboradorController.GetColaboradorById] -  Busca de um colaborador pelo Id {colaboradorId}");

                var colaborador = _colaboradorServices.GetById(colaboradorId);

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ColaboradorController.GetColaboradorById] - Erro ao buscar um colaborador pelo ID {colaboradorId} erro:{ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpGet]
        [Route("colaborador/colaborador-login/{colaboradorLogin}")]
        public IActionResult GetColaboradorByColaboradorLogin(string colaboradorLogin)
        {
            try
            {
                _logger.Information($"[ColaboradorController.GetColaboradorByColaboradorLogin] - Busca de um colaborador pelo login {colaboradorLogin}");

                var colaborador = _colaboradorServices.GetByColaboradorLogin(colaboradorLogin);

                return Ok(colaborador);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ColaboradorController.GetColaboradorByColaboradorLogin] - Erro ao buscar um colaborador pelo login {colaboradorLogin} erro:{ex.Message}");

                return StatusCode(500, ex);
            }
        }

        [HttpPost]
        [Route("colaborador")]
        public IActionResult Salvar(ColaboradorViewModel model)
        {
            try
            {
                _logger.Information($"[ColaboradorControler.Salvar] - Solicitação para salvar um colaborador: {JsonSerializer.Serialize(model)}");

                _colaboradorServices.Salvar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ColaboradorControler.salvar] - Erro ao salvar um colaborador Erro:{ex.Message} com o objeto:{JsonSerializer.Serialize(model)}");
                
                return StatusCode(500, ex);
            }
        }

        [HttpPut]
        [Route("colaborador/{colaboradorId}")]
        public IActionResult Atualizar(int colaboradorId, ColaboradorViewModel model)
        {
            try
            {
                _logger.Information($"[ColaboradorControler.Atualizar] - Solicitação para salvar um colaborador: {colaboradorId} com as informações: {JsonSerializer.Serialize(model)}");
                
                model.ColaboradorId = colaboradorId;
                _colaboradorServices.Atualizar(model);

                return Ok();
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"[ColaboradorControler.Atualizar] - Erro ao Atualizar o Cliente: Erro: {ex.Message} com o objeto: {JsonSerializer.Serialize(model)}");
                
                return StatusCode(500, ex);
            }
        }
    }
}