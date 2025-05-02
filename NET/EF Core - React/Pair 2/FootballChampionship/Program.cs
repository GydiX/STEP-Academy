using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using FootballChampionship.Models;

namespace FootballChampionship
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Завдання 1
                // Додати команди, гравців та матчі
                var team1 = new Team { Name = "Barcelona" };
                var team2 = new Team { Name = "Real Madrid" };

                context.Teams.AddRange(team1, team2);
                context.SaveChanges();

                var player1 = new Player { FullName = "Lionel Messi", Country = "Argentina", Number = 10, Position = "Forward" };
                var player2 = new Player { FullName = "Cristiano Ronaldo", Country = "Portugal", Number = 7, Position = "Forward" };

                context.Players.AddRange(player1, player2);
                context.SaveChanges();

                var match = new Match
                {
                    Team1Id = team1.Id,
                    Team2Id = team2.Id,
                    GoalsTeam1 = 3,
                    GoalsTeam2 = 2,
                    Scorer = "Lionel Messi",
                    MatchDate = DateTime.Now
                };

                context.Matches.Add(match);
                context.SaveChanges();

                // Завдання 2 
                // Показати різницю забитих та пропущених голів для кожної команди
                var teams = context.Teams.Include(t => t.Matches).ToList();
                foreach (var team in teams)
                {
                    var scoredGoals = team.Matches.Sum(m => m.Team1Id == team.Id ? m.GoalsTeam1 : m.GoalsTeam2);
                    var concededGoals = team.Matches.Sum(m => m.Team1Id == team.Id ? m.GoalsTeam2 : m.GoalsTeam1);
                    Console.WriteLine($"{team.Name}: {scoredGoals} - {concededGoals}");
                }

                // Показати повну інформацію про матч
                var matches = context.Matches.Include(m => m.Team1).Include(m => m.Team2).ToList();
                foreach (var m in matches)
                {
                    Console.WriteLine($"Match: {m.Team1.Name} vs {m.Team2.Name}, Score: {m.GoalsTeam1}-{m.GoalsTeam2}, Scorer: {m.Scorer}, Date: {m.MatchDate}");
                }

                // Показати інформацію про матчі у конкретну дату
                var specificDate = DateTime.Now.Date;
                var matchesOnDate = context.Matches.Include(m => m.Team1).Include(m => m.Team2)
                    .Where(m => m.MatchDate.Date == specificDate).ToList();
                foreach (var m in matchesOnDate)
                {
                    Console.WriteLine($"Match on {specificDate}: {m.Team1.Name} vs {m.Team2.Name}, Score: {m.GoalsTeam1}-{m.GoalsTeam2}");
                }

                // Показати усі матчі конкретної команди
                var specificTeam = team1;
                var teamMatches = context.Matches.Include(m => m.Team1).Include(m => m.Team2)
                    .Where(m => m.Team1Id == specificTeam.Id || m.Team2Id == specificTeam.Id).ToList();
                foreach (var m in teamMatches)
                {
                    Console.WriteLine($"Match for {specificTeam.Name}: {m.Team1.Name} vs {m.Team2.Name}, Score: {m.GoalsTeam1}-{m.GoalsTeam2}");
                }

                // Показати усіх гравців, які забили голи у конкретну дату
                var scorersOnDate = context.Matches
                    .Where(m => m.MatchDate.Date == specificDate)
                    .Select(m => m.Scorer)
                    .Distinct()
                    .ToList();
                Console.WriteLine($"Scorers on {specificDate}: {string.Join(", ", scorersOnDate)}");

                // Завдання 3
                // Додати інформацію про матч
                var newMatch = new Match
                {
                    Team1Id = team1.Id,
                    Team2Id = team2.Id,
                    GoalsTeam1 = 1,
                    GoalsTeam2 = 1,
                    Scorer = "New Scorer",
                    MatchDate = DateTime.Now.AddDays(1)
                };

                context.Matches.Add(newMatch);
                context.SaveChanges();

                // Зміна даних існуючого матчу
                var existingMatch = context.Matches.FirstOrDefault(m => m.Team1Id == team1.Id && m.Team2Id == team2.Id);
                if (existingMatch != null)
                {
                    existingMatch.GoalsTeam1 = 2;
                    existingMatch.GoalsTeam2 = 3;
                    context.SaveChanges();
                }

                // Видалити матч
                var matchToDelete = context.Matches.FirstOrDefault(m => m.Team1Id == team1.Id && m.Team2Id == team2.Id && m.MatchDate.Date == specificDate);
                if (matchToDelete != null)
                {
                    Console.WriteLine($"Do you want to delete the match between {matchToDelete.Team1.Name} and {matchToDelete.Team2.Name} on {matchToDelete.MatchDate}? (y/n)");
                    var response = Console.ReadLine();
                    if (response?.ToLower() == "y")
                    {
                        context.Matches.Remove(matchToDelete);
                        context.SaveChanges();
                    }
                }
            }
        }
    }
}