using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IExerciseRepository
    {
        Task AddAsync(Exercise entity);

        IEnumerable<Exercise> GetAll();

        Exercise GetById(int id);

        void Remove(Exercise entity);
        Exercise Update(Exercise exercise);
    }
}
