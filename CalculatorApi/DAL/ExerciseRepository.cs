using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DAL
{
    public class ExerciseRepository : IExerciseRepository
    {
        protected readonly MyContext Context;

        public ExerciseRepository(MyContext context)
        {
            Context = context;
        }

        public async Task AddAsync(Exercise entity)
        {
            await Context.Set<Exercise>().AddAsync(entity);
            Context.SaveChanges();
        }
        public IEnumerable<Exercise> GetAll()
        {
            return Context.Set<Exercise>();
        }

        public Exercise GetById(int id)
        {
            return Context.Set<Exercise>().Find(id);
        }

        public void Remove(Exercise entity)
        {
            Context.Set<Exercise>().Remove(entity);
            Context.SaveChanges();
        }

        public Exercise Update(Exercise exercise)
        {
            Exercise dbExercise = GetById(exercise.ID);
            dbExercise.Number1 = exercise.Number1;
            dbExercise.Number2 = exercise.Number2;
            dbExercise.ExerciseOperator = exercise.ExerciseOperator;
            dbExercise.Result = exercise.Result;
            Context.SaveChanges();
            return GetById(exercise.ID);

        }
    }
}
