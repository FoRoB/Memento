using System.Collections.Generic;

namespace Memento.Models
{
    class FlashcardsSet
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public ICollection<Flashcard>? Flashcards { get; set; }
    }
}
