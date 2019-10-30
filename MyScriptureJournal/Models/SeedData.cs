using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyScriptureJournal.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournalContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournalContext>>()))
            {
                // Look for any movies.
                if (context.JournalEntry.Any())
                {
                    return;   // DB has been seeded
                }

                context.JournalEntry.AddRange(
                    new JournalEntry
                    {
                        Title = "Ten Commandments",
                        EntryDate = DateTime.Parse("2019-10-29"),
                        Book = "Genesis",
                        Reference = "20: 3-17",
                        Notes = "The Ten Commandments are pretty great."
                    },

                    new JournalEntry
                    {
                        Title = "Sacrament Prayers",
                        EntryDate = DateTime.Parse("2019-10-28"),
                        Book = "Doctrine and Covenants",
                        Reference = "20: 77,79",
                        Notes = "Bread and water to remember Christ's atoning sacrifice."
                    },

                    new JournalEntry
                    {
                        Title = "Don't procrastinate",
                        EntryDate = DateTime.Parse("2019-10-27"),
                        Book = "Alma",
                        Reference = "34: 32-34",
                        Notes = "Prepare now."
                    },

                    new JournalEntry
                    {
                        Title = "Be like this",
                        EntryDate = DateTime.Parse("2019-10-26"),
                        Book = "Alma",
                        Reference = "7: 23-24",
                        Notes = "This is a great list of qualities to pursue. Imagine if everyone in the world were like this. There would be no war, no poor, no inequality. There would be peace."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
