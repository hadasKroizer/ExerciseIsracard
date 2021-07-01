using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CalculatorApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {
        ICalculatorService calculatorService;
        public CalculatorController(ICalculatorService _calculatorService)
        {
            calculatorService = _calculatorService;
        }

        [HttpGet]
        public IEnumerable<Exercise> GetExercises()
        {
            return calculatorService.GetExercises();
        }

        [HttpPost]
        public async Task<Exercise> CalculateAsync(Exercise exercise)
        {
            return await calculatorService.GetCalculateAsync(exercise);
        }

        [HttpPut]
        public Exercise UpdateExercise(Exercise exercise)
        {
            return calculatorService.Update(exercise);
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteExercise(int id)
        {
            calculatorService.Delete(id);
        }
    }
}