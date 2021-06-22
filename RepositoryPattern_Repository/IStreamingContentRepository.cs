using System.Collections.Generic;

namespace RepositoryPattern_Repository
{
    public interface IStreamingContentRepository
    {
        void AddContentToDirectory(StreamingContent content);
        bool DeleteContentByTitle(string title);
        bool DeleteExistingContent(StreamingContent content);
        List<StreamingContent> GetAllStreamingContent();
        StreamingContent GetContentByTitle(string title);
        void UpdateStreamingContentDescription(string title, string description);
    }
}