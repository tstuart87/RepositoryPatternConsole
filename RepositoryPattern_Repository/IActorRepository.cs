using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public interface IActorRepository
    {
        bool AddActorToDirectory(Actor actor);
        List<Actor> GetAllActors();
        Actor GetActorById(int id);
        bool DeleteActorById(int id);
        bool DeleteExistingActor(Actor actor);
    }
}
