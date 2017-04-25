using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using BasicAuthentication.Controllers;
using System;
using BasicAuthentication.Models;
using Xunit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ToDoList.Tests
{
    public class ItemsControllerTest
    {
        public ApplicationDbContext _db;

        [Fact]
        public void Get_ViewResult_Index_Test()
        {
            //Arrange
            RolesController controller = new RolesController(_db);

            //Act
            var result = controller.Index();

            //Assert
            Assert.IsType<ViewResult>(result);
        }


    }
}