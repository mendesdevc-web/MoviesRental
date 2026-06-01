using MoveisRental.Core.DomainObjects;
using MoveisRental.Domain.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MoveisRental.Domain.Entities
{
    public class Dvd : Entity
    {
        protected Dvd()
        {
        }

        public Dvd(
            string title,
            int genre, 
            DateTime published,
            int copies, 
            Guid directorId)
        {
            Available = true;
            UpdateTitle(title);
            UpdateGenre(genre);
            UpdatePublished(published);
            UpdateCopies(copies);
            UpdateDirector(directorId);
        }


        public string Title { get; private set; }
        public EGenre Genre { get; private set; }
        public DateTime Published { get; private set; }
        public bool Available { get; private set; }
        public int Copies { get; private set; }
        public Guid DirectorId { get; private set; }
        public Director Director { get;  set; }

        public const int MIN_TITLE_LENGTH = 2;
        public const int MAX_TITLE_LENGTH = 50;

        public void RentCopy()
        {
            if(Copies == 0 || !Available) 
                throw new DomainException($"No copies of Dvd {Title} available for rent.");

            var copies = Copies - 1;
            UpdateCopies(copies);
        }

        public void ReturnCopy()
        {
            if (!Available)
                throw new DomainException($"Dvd {Title} is not available for return.");

            var copies = Copies + 1;
            UpdateCopies(copies);
        }

        public void UpdateTitle(string title)
        {
            if (!Available)
                throw new DomainException($"Dvd {Title} is not available.");

            if (string.IsNullOrWhiteSpace(title) || title.Length < MIN_TITLE_LENGTH || title.Length > MAX_TITLE_LENGTH)
                throw new DomainException($"Invalid name {title} to a Dvd");
            Title = title;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateGenre(int genre)
        {
            if(!Available)
                throw new DomainException($"Dvd {Title} is not available.");
            Genre = genre switch
            { 
                1 => EGenre.Action,
                2 => EGenre.Comedy,
                3 => EGenre.Drama,
                4 => EGenre.Horror,
                5 => EGenre.Animator,
                6 => EGenre.Romance,
                7 => EGenre.Thriller,
                8 => EGenre.Animation,
                9 => EGenre.Documentary,
                10 => EGenre.Fantasy,
                11 => EGenre.Scify,
                12 => EGenre.Musical,
                13 => EGenre.Mystery,
                14 => EGenre.Music,
                15 => EGenre.War,
                16 => EGenre.Kids,
                17 => EGenre.Family,
                18 => EGenre.Crime,
                _ => throw new DomainException($"Invalid genre {genre} for Dvd {Title}.")
            };

            UpdatedAt = DateTime.Now;
        }

        public void UpdatePublished(DateTime date)
        {
            if (!Available)
                throw new DomainException($"Dvd {Title} is not available.");
            var todayDate = DateTime.Now;

            if(todayDate < date )
                throw new DomainException($"Invalid published date {date} for Dvd {Title}.");

            Published = date;
            UpdatedAt = todayDate;
        }

        public void UpdateDirector(Guid directorId)
        {
            if (!Available)
                throw new DomainException($"Dvd {Title} is not available.");

            if (directorId == Guid.Empty)
                throw new DomainException($"Invalid director id {directorId} for Dvd {Title}.");

            DirectorId = directorId;
            UpdatedAt = DateTime.Now;
        }

        public void UpdateCopies(int copies)
        {
            if(!Available)
                throw new DomainException($"Dvd {Title} could not be created.");
            
            if (copies < 0)
                throw new DomainException($"Invalid number of copies {copies} for Dvd {Title}.");

            Copies = copies;
            UpdatedAt = DateTime.Now;
        }

        public void DeleteDvt()
        {
            if (!Available) 
                throw new DomainException("Dvd is not available for deletion.");
            Available = false;
            Copies = 0;
            DeleteAt = DateTime.Now;
        }
    }
}
