using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RepositoryPattern_Repository;

namespace RepositoryPattern_Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreateSCWithTitle_ShouldSetTitle()
        {
            // Arrange
            var title = "The Simpsons Movie";

            // Act
            var scWithTitle = new StreamingContent(title);

            // Assert
            Assert.AreEqual(title, scWithTitle.Title);
        }
        [TestMethod]
        public void CreateSCInRepo_ShouldAddSC()
        {
            // Arrange
            var repo = new MoreTestableRepo();
            var scToAdd = new StreamingContent("The Simpsons Movie");
            int countBeforeAdd = repo._contentDirectory.Count;

            // Act
            repo.AddContentToDirectory(scToAdd);

            int countAfterAdd = repo._contentDirectory.Count;

            // Assert
            // Assert.AreEqual(repo.GetAllStreamingContent().Contains(scToAdd));
            Assert.AreEqual(countBeforeAdd, countAfterAdd - 1);
        }
    }
}
