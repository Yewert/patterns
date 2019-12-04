using FakeItEasy;
using FluentAssertions;
using NUnit.Framework;

namespace hw07
{
    [TestFixture]
    public class Tests
    {
        private IPrinter _printer;
        private IDocumentInfoExtractor _documentInfoExtractor;
        private Context _context;
        
        [SetUp]
        public void SetUp()
        {
            _printer = A.Fake<IPrinter>();
            _documentInfoExtractor = A.Fake<IDocumentInfoExtractor>();
            _context = new Context(_printer, _documentInfoExtractor);
        }
        
        [Test]
        public void BasicScenario()
        {
            _context.InsertMoney(100);
            var path = "path";
            _context.ChooseDevice(DeviceType.UsbDrive);
            A.CallTo(() => _documentInfoExtractor.Get(DeviceType.UsbDrive, path))
                .Returns(new Document(DocumentType.PDF, path, 10));
            _context.ChooseDocument(path);
            _context.PrintDocument();
            _context.ReturnChange().Should().Be(0);
        }
        
        [Test]
        public void GiveCorrectChange()
        {
            _context.InsertMoney(110);
            var path = "path";
            _context.ChooseDevice(DeviceType.UsbDrive);
            A.CallTo(() => _documentInfoExtractor.Get(DeviceType.UsbDrive, path))
                .Returns(new Document(DocumentType.PDF, path, 10));
            _context.ChooseDocument(path);
            _context.PrintDocument();
            _context.ReturnChange().Should().Be(10);
        }

        [Test]
        public void ReprintSame()
        {
            _context.InsertMoney(100);
            var path = "path";
            _context.ChooseDevice(DeviceType.UsbDrive);
            A.CallTo(() => _documentInfoExtractor.Get(DeviceType.UsbDrive, path))
                .Returns(new Document(DocumentType.PDF, path, 5));
            _context.ChooseDocument(path);
            _context.PrintDocument();
            _context.PrintDocument();
            _context.ReturnChange().Should().Be(0);
            A.CallTo(() => _documentInfoExtractor.Get(A<DeviceType>._, A<string>._)).MustHaveHappenedOnceExactly();
            A.CallTo(() => _printer.Print(path)).MustHaveHappenedTwiceExactly();
        }
    }
}