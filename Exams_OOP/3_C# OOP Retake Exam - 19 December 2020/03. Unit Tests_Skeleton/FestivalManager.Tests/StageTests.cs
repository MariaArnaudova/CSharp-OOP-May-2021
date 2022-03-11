// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to Festival Manager (entities/controllers/etc)
// Test ONLY the Stage class. 
namespace FestivalManager.Tests
{
   // using FestivalManager.Entities;
    using NUnit.Framework;
    using System;
    using System.Collections.Generic;

    [TestFixture]
    public class StageTests
    {
        private List<Song> songs;
        private List<Performer> performers;
        private Stage stage;
        private Performer performer;
        private Song song;
        private TimeSpan span;

        [SetUp]

        public void SetUp()
        {
           // var song1 = new Song("Ветрове", new TimeSpan(0, 3, 30));
           // var song2 = new Song("Бурни Нощи", new TimeSpan(0, 2, 30));
           // this.span = new TimeSpan(0, 3, 30);
            this.songs = new List<Song>();
            this.performers = new List<Performer>();
            this.stage = new Stage();
            this.performer = new Performer("Koko", "Last", 30);
            this.song = new Song("Ветрове", new TimeSpan(0, 3, 30));
        }


        [Test]
        public void Ctor_ShouldInitializeCollections()
        {
            //	List<Song> expectedSongs = new List<Song>();
            //	List<Performer> expectedPerformers = new List<Performer>();
            int expectedPerformersCount = 0;
            Assert.AreEqual(expectedPerformersCount, stage.Performers.Count);

        }

        [Test]
        public void Property_ReadOnlyCollection_ShouldReturn_ReadOnlyCollection()
        {
            IReadOnlyCollection<Performer> expectedPerformers = new List<Performer>();
            Assert.AreEqual(expectedPerformers, stage.Performers);
        }

        [Test]
        public void Prop_ReturnsCollectionAsReadOnly()
        {
            Assert.IsInstanceOf<IReadOnlyCollection<Performer>>(this.stage.Performers);
        }

        [Test]

        public void AddPerformer_ShouldAddPerformerCorrectly()
        {
            stage.AddPerformer(performer);
            int expectedCount = 1;
            Assert.AreEqual(expectedCount, this.stage.Performers.Count);
        }

        [Test]
        public void AddPerformer_ShouldThrowExceptionIfPerformerISNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddPerformer(null));
        }

        [Test]
        public void AddPerformer_ShouldThrowExceptionIfPerformerAgeILess18()
        {
            Assert.Throws<ArgumentException>(() => stage.AddPerformer(new Performer("Koko", "Last", 16)));
        }

        [Test]

        public void AddSong_ShouldThrowExceptionIfSongISNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSong(null));
        }


        [Test]

        public void AddSong_ShouldThrowExceptionIfDurationIsLessOneMinutes()
        {
            Assert.Throws<ArgumentException>(() => stage.AddSong(new Song("Ветрове", new TimeSpan(0, 0, 40))));
        }


        [Test]

        public void AddSongToPerformer_ShouldThrowExceptionIfSongNameISNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer(null, "Koko"));
        }

        [Test]

        public void AddSongToPerformer_ShouldThrowExceptionIfPerformerNameISNull()
        {
            Assert.Throws<ArgumentNullException>(() => stage.AddSongToPerformer("Blue", null));
        }

        [Test]

        public void AddSongToPerformer_ShouldIncreaseCountToPerformerListOfSongs()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(song);
            int expectedCount = 1;
            stage.AddSongToPerformer("Ветрове", "Koko Last");
            Assert.AreEqual(expectedCount, performer.SongList.Count);
        }


        [Test]

        public void AddSongToPerformer_ShouldReturnInfoString()
        {
            this.stage.AddPerformer(this.performer);
            this.stage.AddSong(song);

            string expectedMessage = $"{song.Name} (03:30) will be performed by {this.performer.FullName}";
            Assert.AreEqual(expectedMessage, stage.AddSongToPerformer("Ветрове", "Koko Last"));
        }

        [Test]

        public void Play_ReturnStringForSong()
        {
            this.stage.Play();
            string expectedMessage = $"{this.performers.Count} performers played 0 songs";
            Assert.AreEqual(expectedMessage, this.stage.Play());
        }
    }
}