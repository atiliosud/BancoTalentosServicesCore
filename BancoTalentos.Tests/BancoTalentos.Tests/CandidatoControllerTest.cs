using BancoTalentos.CandidatoService.Controllers;
using BancoTalentos.CandidatoService.Model;
using BancoTalentos.CandidatoService.Model.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using Xunit;

namespace BancoTalentos.Tests
{
    public class CandidatoControllerTest
    {
        CandidatoController _controller;
        ICandidatoRepository _repository;
        
        public CandidatoControllerTest(ICandidatoRepository candidatoRepository)
        {
            _repository = candidatoRepository;
            _controller = new CandidatoController(candidatoRepository);
        }

        [Fact]
        public void GetList()
        {
            var okResult = _controller.Get();
            Assert.IsType<OkObjectResult>(okResult.Result);
        }

        [Fact]
        public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
        {
            // Arrange
            var candidato = new Candidato()
            {
                Nome = "Atilio Camargo",
                UltimoNome ="Moreira",
                Email = "atiliosud@gmail.com",
                DataCriacao = DateTime.Now,
                Pretensao = 100
            };

            // Act
            var createdResponse = _controller.Create(candidato) as CreatedAtActionResult;
            var item = createdResponse.Value as Candidato;

            // Assert
            Assert.IsType<Candidato>(item);
            Assert.Equal("Atilio Camargo", item.Nome);
        }
    }
}
