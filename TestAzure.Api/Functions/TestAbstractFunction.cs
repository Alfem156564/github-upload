
using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Core.Contracts;
using TestAzure.Api.Helpers;
using TestAzure.Api.Definition;
using Core.Abstract;

namespace TestAzure.Api.Functions
{
    public class TestAbstractFunction
    {

        public TestAbstractFunction()
        {
        }

        [FunctionName("GetSquareArea")]
        public async Task<IActionResult> GetSquareArea(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "area/square/{side}")] HttpRequest request, int side)
        {
            Square square = new Square(side);

            return new OkObjectResult($"The area of the square is {square.Area()}");
        }

        [FunctionName("GetRectangleArea")]
        public async Task<IActionResult> GetRectangleArea(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "area/rectangle/{side1}/{side2}")] HttpRequest request, int side1, int side2)
        {
            Rectangle rectangle = new Rectangle(side1, side2);

            return new OkObjectResult($"The area of the rectangle is {rectangle.Area()}");
        }

        [FunctionName("GetTriangleArea")]
        public async Task<IActionResult> GetTriangleArea(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "area/triangle/{side1}/{side2}")] HttpRequest request, int side1, int side2)
        {
            Triangle triangle = new Triangle(side1, side2);

            return new OkObjectResult($"The area of the triangle is {triangle.Area()}");
        }

        [FunctionName("GetCircleArea")]
        public async Task<IActionResult> GetCircleArea(
            [HttpTrigger(
                AuthorizationLevel.Anonymous,
                "get",
                Route = "area/circle/{side}")] HttpRequest request, int side)
        {
            Circle circle = new Circle(side);

            return new OkObjectResult($"The area of the circle is {circle.Area()}");
        }
    }
}
