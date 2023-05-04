using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Memento.Models
{
    class FlashcardsSet : IEnumerable<Flashcard>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Flashcard>? Flashcards { get; set; }

        public ICollection<Flashcard> CopyFlashcardsTo(ICollection<Flashcard> toFc)
        {
            if (Flashcards != null)
            {
                foreach (var fc in Flashcards)
                {
                    toFc.Add(new Flashcard()
                    {
                        Question = fc.Question,
                        Answer = fc.Answer,
                        Rating = fc.Rating
                    });
                }
            }
            return toFc;
        }

        public IEnumerator<Flashcard> GetEnumerator()
        {
            if (Flashcards != null)
            {
                foreach (var fc in Flashcards)
                {
                    yield return fc;
                }
            }
            yield break;
        }
        public IEnumerator<Flashcard> GetSortedEnumerator()
        {
            if (Flashcards != null)
            {
                return Flashcards.OrderBy(x => x.Rating).GetEnumerator();
            }
            return GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

}
