using MovieReviewSystem.Library.DataManager;
using MovieReviewSystem.Models;
using System.Collections.Generic;

namespace MovieReviewSystem.DataLoader
{
    internal class ActorDL
    {
        public static void LoadData()
        {
            List<Actor> actors = new List<Actor>
            {
                new Actor(1, "Aiden Turner"),
                new Actor(2, "Emily Blunt"),
                new Actor(3, "Noah Centineo"),
                new Actor(4, "Zoe Saldana"),
                new Actor(5, "Chris Hemsworth"),
                new Actor(6, "Emma Stone"),
                new Actor(7, "Tom Hardy"),
                new Actor(8, "Megan Fox"),
                new Actor(9, "Samuel L. Jackson"),
                new Actor(10, "Jessica Chastain"),
                new Actor(11, "Idris Elba"),
                new Actor(12, "Natalie Portman"),
                new Actor(13, "Henry Cavill"),
                new Actor(14, "Scarlett Johansson"),
                new Actor(15, "Leonardo DiCaprio"),
                new Actor(16, "Margot Robbie"),
                new Actor(17, "Matthew McConaughey"),
                new Actor(18, "Sophie Turner"),
                new Actor(19, "Chris Evans"),
                new Actor(20, "Jessica Biel"),
                new Actor(21, "Ryan Gosling"),
                new Actor(22, "Kate Winslet"),
                new Actor(23, "Javier Bardem"),
                new Actor(24, "Gal Gadot"),
                new Actor(25, "Denzel Washington"),
                new Actor(26, "Charlize Theron"),
                new Actor(27, "Hugh Jackman"),
                new Actor(28, "Julia Roberts"),
                new Actor(29, "Daniel Kaluuya"),
                new Actor(30, "Chris Pratt"),
                new Actor(31, "Emily Ratajkowski"),
                new Actor(32, "Viola Davis"),
                new Actor(33, "Michael B. Jordan"),
                new Actor(34, "Anne Hathaway"),
                new Actor(35, "Jason Momoa"),
                new Actor(36, "Tessa Thompson"),
                new Actor(37, "Ben Affleck"),
                new Actor(38, "Katherine Langford"),
                new Actor(39, "John Boyega"),
                new Actor(40, "Alicia Vikander"),
                new Actor(41, "George Clooney"),
                new Actor(42, "Kate Hudson"),
                new Actor(43, "Olivia Wilde"),
                new Actor(44, "David Schwimmer"),
                new Actor(45, "Lupita Nyong'o"),
                new Actor(46, "Robert Downey Jr."),
                new Actor(47, "Emma Watson"),
                new Actor(48, "Tobey Maguire"),
                new Actor(49, "Mila Kunis"),
                new Actor(50, "Billy Porter"),
                new Actor(51, "Keira Knightley"),
                new Actor(52, "Anthony Mackie"),
                new Actor(53, "Jodie Comer"),
                new Actor(54, "Seth Rogen"),
                new Actor(55, "Liam Hemsworth"),
                new Actor(56, "Michelle Yeoh"),
                new Actor(57, "Donnie Yen"),
                new Actor(58, "Constance Wu"),
                new Actor(59, "Jamie Foxx"),
                new Actor(60, "Florence Pugh"),
                new Actor(61, "Finn Wolfhard"),
                new Actor(62, "Rami Malek"),
                new Actor(63, "Daisy Ridley"),
                new Actor(64, "Janelle Monáe"),
                new Actor(65, "Timothée Chalamet"),
                new Actor(66, "Nicolas Cage"),
                new Actor(67, "Renee Zellweger"),
                new Actor(68, "Kristen Stewart"),
                new Actor(69, "Margaret Qualley"),
                new Actor(70, "Aaron Taylor-Johnson"),
                new Actor(71, "Sophie Okonedo"),
                new Actor(72, "Kurt Russell"),
                new Actor(73, "Bill Nighy"),
                new Actor(74, "Kathy Bates"),
                new Actor(75, "Andy Serkis"),
                new Actor(76, "Octavia Spencer"),
                new Actor(77, "Regina King"),
                new Actor(78, "Mandy Moore"),
                new Actor(79, "John Krasinski"),
                new Actor(80, "Cynthia Erivo")

            };
            foreach (Actor actor in actors)
            {
                ActorDataManager actorDataManager = new ActorDataManager();
                actorDataManager.AddActor(actor.ActorId, actor.ActorName);
            }
        }
    }
}
