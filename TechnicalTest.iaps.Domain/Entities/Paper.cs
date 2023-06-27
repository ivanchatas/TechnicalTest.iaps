using System.ComponentModel.DataAnnotations;

namespace TechnicalTest.iaps.Domain.Entities
{
    public sealed class Paper
    {
        /// <summary>
        /// id: ArXiv ID (can be used to access the paper, see below)
        /// </summary>
        [Key]
        public string Id { get; set; }
        
        /// <summary>
        /// submitter: Who submitted the paper
        /// </summary>
        public string Submitter { get; set; }

        /// <summary>
        /// title: Title of the paper
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// comments: Additional info, such as number of pages and figures
        /// </summary>
        public string? Comments { get; set; }

        /// <summary>
        /// journal-ref: Information about the journal the paper was published in doi: [https://www.doi.org](Digital Object Identifier)
        /// </summary>
        public string? JournalRef { get; set; }

        /// <summary>
        /// abstract: The abstract of the paper
        /// </summary>
        public string Abstract { get; set; }

        public DateTime UpdateDate { get; set; }

        /// <summary>
        /// versions: A version history
        /// </summary>
        public List<PaperVersion> Versions { get; set; } = new();

        /// <summary>
        /// authors: Authors of the paper 
        /// </summary>
        public List<Author> Authors { get; set; } = new();

        /// <summary>
        /// categories: Categories / tags in the ArXiv system
        /// </summary>
        public List<Category> Categories { get; set; } = new();
    }
}
