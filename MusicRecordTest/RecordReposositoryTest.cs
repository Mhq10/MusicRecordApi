using MusicRecordApi.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using MusicRecordApi.Models;

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

        [TestMethod]
        public void AddRecord_AddsRecordSuccessfully()
        {
            //Arrange
            var repository = new RecordsRepository();
            Record newRecord = new Record
            {
                Id = 4,
                Title = "New Record",
                Artist = "New Artist",
                Duration = 120,
                Genre = "Pop",
                Year = 2022
            };

            //Act
            var addedRecord = repository.AddRecord(newRecord);

            //Assert
            Assert.IsNotNull(addedRecord);
            Assert.AreEqual(newRecord.Id, addedRecord.Id);
            Assert.AreEqual(newRecord.Title, addedRecord.Title);
        }

        [TestMethod]
        public void DeleteRecord_DeletesRecordSuccessfully()
        {
            //Arrange
            var repository = new RecordsRepository();
            int recordIdToDelete = 1;

            //Act
            var deletedRecord = repository.DeleteRecord(recordIdToDelete);

            //Assert
            Assert.IsNotNull(deletedRecord);
            Assert.AreEqual(recordIdToDelete, deletedRecord.Id);
        }

        [TestMethod]
        public void DeleteRecord_RecordNotFound_ReturnsNull()
        {
            //Arrange
            var repository = new RecordsRepository();
            int nonExistentRecordId = 999;
            //Act
            var deletedRecord = repository.DeleteRecord(nonExistentRecordId);
            //Assert
            Assert.IsNull(deletedRecord);
        }

        [TestMethod]
        public void UpdateRecord_UpdatesRecordSuccessfully()
        {
            //Arrange
            var repository = new RecordsRepository();
            Record updatedRecord = new Record
            {
                Id = 1,
                Title = "Updated Title",
                Artist = "Updated Artist",
                Duration = 150,
                Genre = "Rock",
                Year = 2021
            };
            //Act
            var result = repository.UpdateRecord(updatedRecord);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(updatedRecord.Id, result.Id);
            Assert.AreEqual(updatedRecord.Title, result.Title);
        }

        [TestMethod]
        public void UpdateRecord_RecordNotFound_ThrowsArgumentException()
        {
            //Arrange
            var repository = new RecordsRepository();
            Record nonExistentRecord = new Record
            {
                Id = 999,
                Title = "Non-existent Record",
                Artist = "Unknown Artist",
                Duration = 100,
                Genre = "Unknown",
                Year = 2020
            };
            
            //Act & Assert
            Assert.ThrowsExactly<ArgumentException>(() => repository.UpdateRecord(nonExistentRecord));
        }
    }
}