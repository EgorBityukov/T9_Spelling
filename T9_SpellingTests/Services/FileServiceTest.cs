using Moq;
using T9_Spelling.Providers;
using T9_Spelling.Services;

namespace T9_SpellingTests.Services
{
    public class FileServiceTest
    {
        private Mock<IFileProvider> _fileProviderMock;
        public FileService _sut;

        [SetUp]
        public void Setup()
        {
            _fileProviderMock = new Mock<IFileProvider>();
            _sut = new FileService(_fileProviderMock.Object);
        }

        [Test]
        public void EmptyPath()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _sut.GetRowsAsync(""));
        }

        [Test]
        public void InvalidPath()
        {
            Assert.ThrowsAsync<ArgumentException>(() => _sut.GetRowsAsync("qwe/d"));
        }

        [Test]
        public async Task ReturnsRows()
        {
            string[] expected = new string[] { "1", "2" };
            _fileProviderMock.Setup(s => s.GetAllLinesAsync(It.IsAny<string>())).ReturnsAsync(expected);

            var actual = await _sut.GetRowsAsync("C:/Input.txt");
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}