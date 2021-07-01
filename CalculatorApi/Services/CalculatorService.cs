
using DAL;
using Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services
{
    public class CalculatorService :ICalculatorService
    {
        IExerciseRepository repository;

        public CalculatorService(IExerciseRepository _repository)
        {
            repository = _repository;
        }

        public void Delete(int id)
        {
            repository.Remove(repository.GetById(id));
        }

        public async Task<Exercise> GetCalculateAsync(Exercise exercise)
        {
            exercise.Result = Calculate(exercise);
            await repository.AddAsync(exercise);
            return exercise;
        }

        public IEnumerable<Exercise> GetExercises()
        {
            return repository.GetAll();
        }

        public Exercise Update(Exercise exercise)
        {
            exercise.Result = Calculate(exercise);
            return repository.Update(exercise);

        }

        private double Calculate(Exercise exercise)
        {
            switch (exercise.ExerciseOperator)
            {
                case Operator.Plus:
                    return exercise.Number1 + exercise.Number2;
                case Operator.Minus:
                    return exercise.Number1 - exercise.Number2;
                case Operator.Multiple:
                    return exercise.Number1 * exercise.Number2;
                case Operator.Divide:
                    if (exercise.Number2 > 0)
                    {
                        return exercise.Number1 / exercise.Number2;
                    }
                    return 0;
            }

            return 0;
        }
    }
}
