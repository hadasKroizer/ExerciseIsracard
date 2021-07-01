using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface ICalculatorService
    {
        Task<Exercise> GetCalculateAsync(Exercise exercise);
        Exercise Update(Exercise exercise);
        void Delete(int id);
        IEnumerable<Exercise> GetExercises();
    }
}
