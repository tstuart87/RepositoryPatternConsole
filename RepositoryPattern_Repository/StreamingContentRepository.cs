using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryPattern_Repository
{
    public class StreamingContentRepository : IStreamingContentRepository
    {
        private readonly List<StreamingContent> _contentDirectory = new List<StreamingContent>();

        //Build out our CRUD methods

        //CREATE
        public bool AddContentToDirectory(StreamingContent content)
        {
            int contentDirectoryCount = _contentDirectory.Count();

            _contentDirectory.Add(content);

            if (_contentDirectory.Count() == contentDirectoryCount + 1)
            {
                return true;
            }

            return false;
        }

        //READ
        //Get all our Streaming Content objects from our directory
        public List<StreamingContent> GetAllStreamingContent()
        {
            return _contentDirectory;
        }

        //Get Streaming Content object by title
        public StreamingContent GetContentByTitle(string title)
        {
            foreach (StreamingContent item in _contentDirectory)
            {
                if (item.Title == title)
                {
                    return item;
                }
            }

            return null;
        }


        //UPDATE
        public void UpdateStreamingContentDescription(string title, string description)
        {
            StreamingContent content = GetContentByTitle(title);

            content.Description = description;
        }


        //DELETE
        public bool DeleteExistingContent(StreamingContent content)
        {
            return _contentDirectory.Remove(content);
        }


        public bool DeleteContentByTitle(string title)
        {
            StreamingContent content = GetContentByTitle(title);

            return DeleteExistingContent(content);
        }

        public List<StreamingContent> GetContentByTitleSearch(string title)
        {
            List<StreamingContent> listOfContent = new List<StreamingContent>();

            foreach (var content in _contentDirectory)
            {
                if (content.Title.ToLower().Contains(title.ToLower()))
                {
                    listOfContent.Add(content);
                }
            }

            if (listOfContent.Count() == 0)
            {
                return null;
            }

            return listOfContent;
        }
    }
}
