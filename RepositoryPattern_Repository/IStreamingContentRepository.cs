using System.Collections.Generic;

namespace RepositoryPattern_Repository
{
    public interface IStreamingContentRepository
    {
        bool AddContentToDirectory(StreamingContent content);
        bool DeleteContentByTitle(string title);
        bool DeleteExistingContent(StreamingContent content);
        List<StreamingContent> GetAllStreamingContent();
        StreamingContent GetContentByTitle(string title);
        void UpdateStreamingContentDescription(string title, string description);
        List<StreamingContent> GetContentByTitleSearch(string title);
    }
}