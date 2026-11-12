using MusicRecordApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace MusicRecordTest
{
    [ExcludeFromCodeCoverage]
    [TestClass]
    public class RecordReposositoryTest
    {
        [TestMethod]
        public void GetAllRecords_ReturnsAllRecords()
        {
            //Arrange
            var repository = new RecordsRepository();

            //Act
            var result = repository.GetAllRecords();

            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }

        [TestMethod]
        public void GetAllRecords_FilterByTitle_ReturnsFilteredRecords()
        {
            //Arrange
            var repository = new RecordsRepository();
            string titleFilter = "Back in Black";
            //Act
            var result = repository.GetAllRecords(title: titleFilter);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(titleFilter, result[0].Title);
        }

        [TestMethod]
        public void GetAllRecords_FilterByArtist_ReturnsFilteredRecords()
        {
            //Arrange
            var repository = new RecordsRepository();
            string artistFilter = "ACDC";
            //Act
            var result = repository.GetAllRecords(artist: artistFilter);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(artistFilter, result[0].Artist);
        }

        [TestMethod]
        public void GetAllRecords_FilterByGenre_ReturnsFilteredRecords()
        {
            //Arrange
            var repository = new RecordsRepository();
            string genreFilter = "Hip Hop";
            //Act
            var result = repository.GetAllRecords(genre: genreFilter);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(genreFilter, result[0].Genre);
        }

        [TestMethod]
        public void GetAllRecords_FilterByYear_ReturnsFilteredRecords()
        {
            //Arrange
            var repository = new RecordsRepository();
            int yearFilter = 2020;
            //Act
            var result = repository.GetAllRecords(year: yearFilter);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(yearFilter, result[0].Year);
        }
    }
}