using RepositoryPattern_Repository.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public class ActorRepository : IActorRepository
    {
        private readonly List<Actor> _actorDirectory = new List<Actor>();

        public bool AddActorToDirectory(Actor actor)
        {
            int actorDirectoryCount = _actorDirectory.Count();
            _actorDirectory.Add(actor);

            if (_actorDirectory.Count() == actorDirectoryCount + 1)
            {
                return true;
            }

            return false;
        }

        public List<Actor> GetAllActors()
        {
            return _actorDirectory;
        }

        public Actor GetActorById(int id)
        {
            foreach(var actor in _actorDirectory)
            {
                if(actor.Id == id)
                {
                    return actor;
                }
            }

            return null;
        }

        public bool DeleteActorById(int id)
        {
            Actor actor = GetActorById(id);

            if (actor != null)
            {
                return DeleteExistingActor(actor);
            }

            return false;
        }

        public bool DeleteExistingActor(Actor actor)
        {
            return _actorDirectory.Remove(actor);
        }
    }
}
