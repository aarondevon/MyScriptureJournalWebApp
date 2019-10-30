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
        
        // Search functionality
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        // Requires using Microsoft.AspNetCore.Mvc.Rendering;
        //public SelectList Books { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string Book { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchSelection { get; set; }
        public async Task OnGetAsync()
        {
            var entries = from m in _context.JournalEntry
                          select m;

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
