using System;
using System.Collections.Generic;
using System.Linq;
using MovieReviewSystem.Views;

namespace MovieReviewSystem.Controllers
{
    internal class MainMenuController
    {
        IView? view;
        public bool HandleChoice(string choice)   //Redirects to different page or executes method based on the choice
        {
            switch (choice)
            {
                //Console.WriteLine("1. View All Movie"); - show rating and total number of reviews
                //Console.WriteLine("2. View A Movie"); - show ratings
                //Console.WriteLine("3. Rate a Movie"); - done
                //Console.WriteLine("4. Review a Movie"); - done
                //Console.WriteLine("5. React to Movies"); - done
                //Console.WriteLine("6. Manage my personal List"); - done
                //Console.WriteLine("7. Search / Filter Movie");
                //Console.WriteLine("0. Logout");
                case "1":
                    {
                        view = new AllMediaView(); //View all Movie
                        view.Initialize();
                        break;
                    }
                case "2":
                    {
                        view = new SingleMediaView(); //View a Movie
                        view.Initialize();
                        break;
                    }
                case "3":
                    {
                        view = new RateMediaView(); //Rate a movie
                        view.Initialize();
                        break;
                    }
                case "4":
                    {
                        view = new ReviewMediaView();//Review a movie
                        view.Initialize();
                        break;
                    }
                case "5":
                    {
                        view = new ReactMediaView();
                        view.Initialize();
                        break;
                    }
                case "6":
                    {
                        view = new PersonalMediaView();
                        view.Initialize();
                        break;
                    }
                case "7":
                    {
                        view = new FilterMediaView();
                        view.Initialize();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid choice");
                        return false;
                    }

            }
            return true;
        }
    }
}
