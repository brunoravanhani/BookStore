using BookStore.Domain.Interface.Service;
using BookStore.Domain.ViewModel;
using BookStore.Test.Mocks;
using BookStore.WebApp.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace BookStore.Test
{
    public class AutorControllerTest
    {

        IAutorService autorService;
        AutorController autorController;

        public AutorControllerTest()
        {
            autorService = new AutorServiceMock();
            autorController = new AutorController(autorService);
        }

        [Fact]
        public void TestGet()
        {
            var result = autorController.Get();
            var objectResult = Assert.IsType<OkObjectResult>(result);
            var values = Assert.IsAssignableFrom<IEnumerable<AutorViewModel>>(objectResult.Value);
            Assert.Single(values);
        }

        [Fact]
        public void TestGetPorId_QuandoEncontra()
        {
            var result = autorController.Get(1);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.IsAssignableFrom<AutorViewModel>(objectResult.Value);
        }

        [Fact]
        public void TestGetPorId_QuandoNaoEncontra()
        {
            var result = autorController.Get(2);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Null(objectResult.Value);
        }

        [Fact]
        public void TestPost()
        {
            var model = new AutorViewModel
            {
                IdAutor = 2,
                Nome = "Carl Sagan"
            };

            var result = autorController.Post(model);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(model, objectResult.Value);
            var resultGet = autorController.Get();
            var objectResultGet = Assert.IsType<OkObjectResult>(resultGet);
            var valuesGet = Assert.IsAssignableFrom<IEnumerable<AutorViewModel>>(objectResultGet.Value);
            Assert.Equal(2, valuesGet.Count());
        }

        [Fact]
        public void TestPut()
        {
            var model = new AutorViewModel
            {
                IdAutor = 1,
                Nome = "J.K. Rolling"
            };

            var result = autorController.Put(model);
            var objectResult = Assert.IsType<OkObjectResult>(result);
            Assert.Same(model, objectResult.Value);
            var resultGet = autorController.Get(1);
            var objectResultGet = Assert.IsType<OkObjectResult>(resultGet);
            Assert.Same(model, objectResultGet.Value);
        }

        [Fact]
        public void TestDelete()
        {
          
            var result = autorController.Delete(2);
            var objectResult = Assert.IsType<OkResult>(result);

            var resultGet = autorController.Get();
            var objectResultGet = Assert.IsType<OkObjectResult>(resultGet);
            var valuesGet = Assert.IsAssignableFrom<IEnumerable<AutorViewModel>>(objectResultGet.Value);
            Assert.Single(valuesGet);
        }
    }
}
