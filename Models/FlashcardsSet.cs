using System.Collections.Generic;

namespace Memento.Models
{
    class FlashcardsSet
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public ICollection<Flashcard>? Flashcards { get; set; }
    }
}
