using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyScriptureJournal.Models;

namespace MyScriptureJournal.Pages.Journal
{
    public class IndexModel : PageModel
    {
        private readonly MyScriptureJournal.Models.MyScriptureJournalContext _context;

        public IndexModel(MyScriptureJournal.Models.MyScriptureJournalContext context)
        {
            _context = context;
        }

        public IList<JournalEntry> JournalEntry { get;set; }
        
        // Sorting
        public string BookSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSelection { get; set; }
        public async Task OnGetAsync(string sortOrder)
        {
            var entries = from m in _context.JournalEntry
                          select m;
            // Sort
            BookSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            switch (sortOrder)
            {
                case "name_desc":
                    entries = entries.OrderByDescending(s => s.Book);
                    break;
                case "Date":
                    entries = entries.OrderBy(s => s.EntryDate);
                    break;
                case "date_desc":
                    entries = entries.OrderByDescending(s => s.EntryDate);
                    break;
                default:
                    entries = entries.OrderBy(s => s.Book);
                    break;
            }

            // Search
            if (SearchSelection == "Book")
            {
                if (!string.IsNullOrEmpty(SearchString))
                {
                    entries = entries.Where(s => s.Book.Contains(SearchString));
                }
            }
            else if (SearchSelection == "Notes")
            {
                if (!string.IsNullOrEmpty(SearchSelection))
                {
                    entries = entries.Where(x => x.Notes.Contains(SearchString));
                }
            }

            JournalEntry = await entries.ToListAsync();
        }
    }
}
