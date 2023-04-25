namespace Memento.Models
{
    class Flashcard
    {
        public string Question { get; set; } = string.Empty;
        public string Answer { get; set; } = string.Empty;
        public int Rating { get; set; }
    }
}
