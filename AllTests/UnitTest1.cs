using Tester;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AllTests
{
    public class UnitTest1
    {
        string SourcePath = "D:\\Cal\\2021\\СПП\\Tester\\TestHere";
        string PathToGenerated = "D:\\Cal\\2021\\СПП\\GeneratedTests\\Tests";

        IEnumerable<string> files;
        string[] generatedFiles;

        [SetUp]
        public void Setup()
        {
            files = Directory.GetFiles(SourcePath);
        }

        [Test]
        public void FilesNumber()
        {
            int expected = 1;
            int actual = files.Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestsGenerationSucceedsTest()
        {
            if (!Directory.Exists(PathToGenerated))
            {
                Directory.CreateDirectory(PathToGenerated);
            }
            try
            {
                Task task = new GeneratorStarter().Generate(files, PathToGenerated, 5);
                task.Wait();
                Assert.IsTrue(true);
            }
            catch (Exception e)
            {
                //Console.WriteLine(e+"CUM");
                Assert.Fail(e.Message);
            }
        }

        [Test]
        public void CorrectNumberOfGeneratedFilesTest()
        {
            if (!Directory.Exists(PathToGenerated))
            {
                Directory.CreateDirectory(PathToGenerated);
            }
            Task task = new GeneratorStarter().Generate(files, PathToGenerated, 5);
            task.Wait();
            generatedFiles = Directory.GetFiles(PathToGenerated);
            int expected = 2;
            int actual = generatedFiles.Length;
            Assert.AreEqual(expected, actual);
        }
    }
}